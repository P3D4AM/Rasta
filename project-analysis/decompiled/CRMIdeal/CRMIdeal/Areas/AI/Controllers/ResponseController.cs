using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ViewModel.AI;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.AI.Controllers;

public class ResponseController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	private CRMSpIIEntities dbII = new CRMSpIIEntities();

	private const string FinalSystemPrompt = "فقط یک JSON object معتبر برگردان؛ بدون هیچ متن، توضیح، Markdown یا کاراکتر اضافی. خروجی باید مستقیما\u064b با { شروع و با } پایان یابد.\r\nبرای هر پرامپت، یک کلید عددی متوالی (1، 2، 3، ...) بساز. مقدار هر کلید باید شامل این فیلدها باشد:\r\n- prompt_id: شناسه پرامپت یا null\r\n- prompt_title: متن کامل پرامپت\r\n- answer: پاسخ کامل بر اساس داده\u200cها\r\n\r\nساختار:\r\n{\r\n  \"1\": {\r\n    \"prompt_id\": \"1\",\r\n    \"prompt_title\": \"متن کامل پرامپت\",\r\n    \"answer\": \"پاسخ کامل بر اساس داده\u200cها\"\r\n  }\r\n}";

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actAIResponse")]
	public ActionResult Index(int projectId)
	{
		base.ViewBag.IsBuying = VersionBuyer.AI;
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)db.CRMspSelectCrmProjectsById(projectId, lCID, result));
		if (cRMspSelectCrmProjectsById_Result == null)
		{
			return RedirectToAction("ShowMessage", "Home", (object)new
			{
				area = "",
				message = Messages.MsgErrorProjectNotFound,
				type = "error"
			});
		}
		base.ViewBag.ProjectId = projectId;
		base.ViewBag.ProjectFullTitle = cRMspSelectCrmProjectsById_Result.prjTitle + cRMspSelectCrmProjectsById_Result.prjPostFix;
		base.ViewBag.ProjectCompany = cRMspSelectCrmProjectsById_Result.prjCompany ?? "";
		return View();
	}

	[AjaxOnly]
	public JsonResult GetAIResponsesByProjectId(int projectId, int pageNumber, int pageSize)
	{
		try
		{
			using HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			string content = JsonConvert.SerializeObject(new
			{
				PromptGroupId = 0,
				PageNumber = pageNumber,
				PageSize = pageSize,
				UserId = UserLogin.CurrentUser.UserId,
				LanguageId = lCID,
				ProjectId = projectId
			});
			string aIDomain = SysSeting.Get().AIDomain;
			if (string.IsNullOrEmpty(aIDomain))
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.msgErrorAIDomainNotFound,
					Data = new
					{
						TotalCount = 0,
						PageNumber = pageNumber,
						PageSize = pageSize,
						TotalPages = 0,
						HasNextPage = false
					}
				}, JsonRequestBehavior.AllowGet);
			}
			string requestUri = aIDomain + "/api/Response/Index";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
			if (result2.IsSuccessStatusCode)
			{
				List<AIResponseViewModel> list = JsonConvert.DeserializeObject<ServiceResult<List<AIResponseViewModel>>>(result2.Content.ReadAsStringAsync().Result).Data ?? new List<AIResponseViewModel>();
				if (list != null && Enumerable.Any<AIResponseViewModel>((IEnumerable<AIResponseViewModel>)list))
				{
					foreach (AIResponseViewModel item in list)
					{
						if (item.ResponseDate != default(DateTime))
						{
							_ = item.ResponseDate;
							item.ResponseDateStr = DateTimeClass.GetLocalDate(item.ResponseDate).Value.ToString("yyyy/MM/dd HH:mm:ss");
						}
					}
				}
				int num = ((list != null && Enumerable.Any<AIResponseViewModel>((IEnumerable<AIResponseViewModel>)list)) ? list[0].TotalCount : 0);
				return Json(new
				{
					Status = 1,
					Message = "",
					Data = new
					{
						Items = list,
						TotalCount = num,
						PageNumber = pageNumber,
						PageSize = pageSize,
						TotalPages = (int)Math.Ceiling((double)num / (double)pageSize),
						HasNextPage = (pageNumber * pageSize < num)
					}
				}, JsonRequestBehavior.AllowGet);
			}
			return Json(new
			{
				Status = 0,
				Message = Messages.msgErrorOperationFailed,
				Data = new
				{
					Items = new List<AIResponseViewModel>(),
					TotalCount = 0,
					PageNumber = pageNumber,
					PageSize = pageSize,
					TotalPages = 0,
					HasNextPage = false
				}
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new
			{
				Status = 0,
				Message = Messages.msgErrorOperationFailed,
				Data = new
				{
					Items = new List<AIResponseViewModel>(),
					TotalCount = 0,
					PageNumber = pageNumber,
					PageSize = pageSize,
					TotalPages = 0,
					HasNextPage = false
				}
			}, JsonRequestBehavior.AllowGet);
		}
	}

	public JsonResult GetAIPromptGroups()
	{
		try
		{
			List<AIPromptGroupViewModel> list = new List<AIPromptGroupViewModel>();
			using (HttpClient httpClient = new HttpClient())
			{
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string content = JsonConvert.SerializeObject(new
				{
					UserId = UserLogin.CurrentUser.UserId,
					LanguageId = lCID
				});
				string aIDomain = SysSeting.Get().AIDomain;
				if (string.IsNullOrEmpty(aIDomain))
				{
					base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
					return Json(list, JsonRequestBehavior.AllowGet);
				}
				string requestUri = aIDomain + "/api/PromptGroup/GetAll";
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
				if (result2.IsSuccessStatusCode)
				{
					list = Enumerable.ToList<AIPromptGroupViewModel>(Enumerable.Select<AIPromptGroupViewModel, AIPromptGroupViewModel>((IEnumerable<AIPromptGroupViewModel>)JsonConvert.DeserializeObject<ServiceResult<List<AIPromptGroupViewModel>>>(result2.Content.ReadAsStringAsync().Result).Data, (Func<AIPromptGroupViewModel, AIPromptGroupViewModel>)((AIPromptGroupViewModel pg) => new AIPromptGroupViewModel
					{
						PromptGroupId = pg.PromptGroupId,
						Title = pg.Title
					})));
					base.ViewBag.PromptGroups = Enumerable.ToList<SelectListItem>(Enumerable.Select<AIPromptGroupViewModel, SelectListItem>((IEnumerable<AIPromptGroupViewModel>)list, (Func<AIPromptGroupViewModel, SelectListItem>)((AIPromptGroupViewModel g) => new SelectListItem
					{
						Value = g.PromptGroupId.ToString(),
						Text = g.Title
					})));
				}
			}
			return Json(list, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
		}
	}

	[AjaxOnly]
	public JsonResult GetConversationsByProjectId(int projectId, int companyId, int pageNumber, int pageSize)
	{
		try
		{
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<AIspSelectCompanyConversationsByProject_Result> list = Enumerable.ToList<AIspSelectCompanyConversationsByProject_Result>((IEnumerable<AIspSelectCompanyConversationsByProject_Result>)dbII.AIspSelectCompanyConversationsByProject(companyId, projectId, UserLogin.CurrentUser.UserId, lCID, result, centerId, pageNumber, pageSize));
			foreach (AIspSelectCompanyConversationsByProject_Result item in list)
			{
				item.cnvsDateTimeStr = (item.cnvsDateTime.HasValue ? DateTimeClass.GetLocalDate(item.cnvsDateTime.Value)?.ToString("yyyy/MM/dd") : "");
			}
			int num = ((list != null && Enumerable.Any<AIspSelectCompanyConversationsByProject_Result>((IEnumerable<AIspSelectCompanyConversationsByProject_Result>)list)) ? list[0].TotalCount : 0);
			return Json(new
			{
				Status = 1,
				Message = "",
				Data = new
				{
					Items = list,
					TotalCount = num,
					PageNumber = pageNumber,
					PageSize = pageSize,
					TotalPages = (int)Math.Ceiling((double)num / (double)pageSize),
					HasNextPage = (pageNumber * pageSize < num)
				}
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new
			{
				Status = 0,
				Message = Messages.msgErrorOperationFailed,
				Data = new
				{
					Items = new List<AIspSelectCompanyConversationsByProject_Result>(),
					TotalCount = 0,
					PageNumber = pageNumber,
					PageSize = pageSize,
					TotalPages = 0,
					HasNextPage = false
				}
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[DynamicAuthorize(ControllerName = "frmAIResponse", ActionName = "actInsert")]
	public ActionResult InsertEdit(int projectId)
	{
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)db.CRMspSelectCrmProjectsById(projectId, lCID, result));
		if (cRMspSelectCrmProjectsById_Result == null)
		{
			base.ViewBag.Error = Messages.MsgErrorProjectNotFound;
			return View(new AIAnswerViewModel());
		}
		GetAIPromptGroups();
		GetSettings();
		GetUserCreditBalance();
		base.ViewBag.ProjectId = projectId;
		base.ViewBag.CompanyId = cRMspSelectCrmProjectsById_Result.prjCompanyId;
		base.ViewBag.ProjectCompany = cRMspSelectCrmProjectsById_Result.prjCompany;
		return View(new AIAnswerViewModel());
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmAIResponseDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(AIAnswerViewModel model)
	{
		try
		{
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			CRMspSelectCrmProjectsById_Result project = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)db.CRMspSelectCrmProjectsById(model.ProjectId, lCID, result));
			if (project == null)
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.MsgErrorProjectNotFound
				});
			}
			_ = project.prjCompanyId;
			if (!VersionBuyer.AI)
			{
				return Json(new
				{
					Status = -1,
					IsBuyVersion = true,
					Message = Messages.VersionBuyAI
				});
			}
			if (model.ConversationIds == null || !Enumerable.Any<int>((IEnumerable<int>)model.ConversationIds))
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.msgErrorNoConversationSelected
				});
			}
			if (model.PromptIds == null || !Enumerable.Any<int>((IEnumerable<int>)model.PromptIds))
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.msgErrorNoPromptSelected
				});
			}
			if (model.ConversationIds.Count >= 100)
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.msgErrorAIConversationCountExceeded
				});
			}
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<AIspSelectCompanyConversationsByProject_Result> conversations = Enumerable.ToList<AIspSelectCompanyConversationsByProject_Result>((IEnumerable<AIspSelectCompanyConversationsByProject_Result>)dbII.AIspSelectCompanyConversationsByProject(project.prjCompanyId, model.ProjectId, UserLogin.CurrentUser.UserId, lCID, result, centerId, 0, 0));
			if (!Enumerable.All<int>((IEnumerable<int>)model.ConversationIds, (Func<int, bool>)((int item) => Enumerable.Contains<int>(Enumerable.Select<AIspSelectCompanyConversationsByProject_Result, int>((IEnumerable<AIspSelectCompanyConversationsByProject_Result>)conversations, (Func<AIspSelectCompanyConversationsByProject_Result, int>)((AIspSelectCompanyConversationsByProject_Result c) => c.ConversationID)), item))))
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.MsgErrorSelectedConversationsNotFound
				});
			}
			List<AIspSelectCompanyConversationsByProject_Result> list = Enumerable.ToList<AIspSelectCompanyConversationsByProject_Result>(Enumerable.Where<AIspSelectCompanyConversationsByProject_Result>((IEnumerable<AIspSelectCompanyConversationsByProject_Result>)conversations, (Func<AIspSelectCompanyConversationsByProject_Result, bool>)((AIspSelectCompanyConversationsByProject_Result c) => model.ConversationIds.Contains(c.ConversationID))));
			foreach (AIspSelectCompanyConversationsByProject_Result item in list)
			{
				item.cnvsDateTimeStr = (item.cnvsDateTime.HasValue ? DateTimeClass.GetLocalDate(item.cnvsDateTime.Value)?.ToString("yyyy/MM/dd") : "");
			}
			string content = JsonConvert.SerializeObject(new
			{
				LanguageId = lCID,
				UserId = UserLogin.CurrentUser.UserId,
				PromptIds = model.PromptIds,
				InputPrompts = new List<string>(),
				ProviderId = 0,
				ModelId = 0,
				SystemPrompt = "",
				Temperature = 0,
				MaxTokens = 0,
				ResponseTypeId = 0,
				InputData = JsonConvert.SerializeObject(Enumerable.Select((IEnumerable<AIspSelectCompanyConversationsByProject_Result>)list, (AIspSelectCompanyConversationsByProject_Result c) => new
				{
					ConversationId = c.ConversationID,
					Text = string.Format(Messages.AIConversationSummaryTemplate, c.cnvsUser, project.prjCompany + " " + c.cnvsPerson, c.cnvsDateTimeStr, c.cnvsStatus, c.cnvsDesc)
				})),
				CompanyId = project.prjCompanyId,
				InputInfoJs = JsonConvert.SerializeObject(new
				{
					ProjectId = model.ProjectId,
					ConversationIds = string.Join(",", model.ConversationIds)
				})
			});
			using HttpClient httpClient = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(800.0)
			};
			string aIDomain = SysSeting.Get().AIDomain;
			if (string.IsNullOrEmpty(aIDomain))
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.msgErrorAIDomainNotFound
				});
			}
			string requestUri = aIDomain + "/api/Answer/GetAnswer";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			bool result2 = false;
			bool.TryParse(UserAIInProccess.Get(UserLogin.CurrentUser.UserId).ToString(), out result2);
			if (result2)
			{
				return Json(new
				{
					Status = 0,
					Message = Messages.msgErrorAiProcessingQueueConflict
				});
			}
			UserAIInProccess.Update(UserLogin.CurrentUser.UserId, value: true);
			if (result <= 0)
			{
				result = 1065;
			}
			HttpResponseMessage result3 = httpClient.PostAsync(requestUri, content2).Result;
			if (result3.IsSuccessStatusCode)
			{
				ServiceResult<bool> serviceResult = JsonConvert.DeserializeObject<ServiceResult<bool>>(result3.Content.ReadAsStringAsync().Result);
				UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
				if (serviceResult != null && serviceResult.Data)
				{
					return Json(new
					{
						Status = 1,
						Message = Messages.msgSuccessAction
					});
				}
				return Json(new
				{
					Status = 0,
					Message = ((serviceResult != null) ? serviceResult.Message : Messages.msgErrorOperationFailed)
				});
			}
			UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
			return Json(new
			{
				Status = 0,
				Message = Messages.msgErrorOperationFailed
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			try
			{
				if (UserLogin.CurrentUser != null)
				{
					UserAIInProccess.Update(UserLogin.CurrentUser.UserId);
				}
			}
			catch
			{
			}
			return Json(new
			{
				Status = 0,
				Message = Messages.msgErrorOperationFailed
			});
		}
	}

	public JsonResult GetAllPrompts(int promptGroupId, int pageSize = 1, int pageNumber = 12)
	{
		try
		{
			List<AIPromptViewModel> list = new List<AIPromptViewModel>();
			using (HttpClient httpClient = new HttpClient())
			{
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string content = JsonConvert.SerializeObject(new
				{
					PromptGroupId = promptGroupId,
					PageNumber = pageNumber,
					PageSize = pageSize,
					UserId = UserLogin.CurrentUser.UserId,
					LanguageId = lCID
				});
				string aIDomain = SysSeting.Get().AIDomain;
				if (string.IsNullOrEmpty(aIDomain))
				{
					return Json(new
					{
						Status = 0,
						Message = Messages.msgErrorAIDomainNotFound,
						Data = new { }
					}, JsonRequestBehavior.AllowGet);
				}
				string requestUri = aIDomain + "/api/Prompt/Index";
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
				if (result2.IsSuccessStatusCode)
				{
					list = Enumerable.ToList<AIPromptViewModel>(Enumerable.Select<AIPromptViewModel, AIPromptViewModel>((IEnumerable<AIPromptViewModel>)JsonConvert.DeserializeObject<ServiceResult<List<AIPromptViewModel>>>(result2.Content.ReadAsStringAsync().Result).Data, (Func<AIPromptViewModel, AIPromptViewModel>)((AIPromptViewModel p) => new AIPromptViewModel
					{
						PromptGroupId = p.PromptGroupId,
						PrTitle = p.PrTitle,
						PrData = p.PrData,
						PromptId = p.PromptId,
						TotalCount = p.TotalCount
					})));
				}
			}
			int? num = ((list != null && Enumerable.Any<AIPromptViewModel>((IEnumerable<AIPromptViewModel>)list)) ? list[0].TotalCount : new int?(0));
			return Json(new
			{
				Status = 1,
				Message = "",
				Data = new
				{
					Items = list,
					TotalCount = num,
					PageNumber = pageNumber,
					PageSize = pageSize,
					TotalPages = (int)Math.Ceiling((double)num.Value / (double)pageSize),
					HasNextPage = (pageNumber * pageSize < num)
				}
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new
			{
				Status = 0,
				Message = Messages.msgErrorOperationFailed,
				Data = new
				{
					Items = new List<AIPromptViewModel>(),
					TotalCount = 0,
					PageNumber = pageNumber,
					PageSize = pageSize,
					TotalPages = 0,
					HasNextPage = false
				}
			}, JsonRequestBehavior.AllowGet);
		}
	}

	public ActionResult GetSettings()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		AISettingViewModel aISettingViewModel = new AISettingViewModel();
		try
		{
			using HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string content = JsonConvert.SerializeObject(new
			{
				LanguageId = lCID,
				UserId = UserLogin.CurrentUser.UserId
			});
			string aIDomain = SysSeting.Get().AIDomain;
			if (string.IsNullOrEmpty(aIDomain))
			{
				return Json(new
				{
					model = aISettingViewModel,
					Message = Messages.msgErrorAIDomainNotFound
				}, JsonRequestBehavior.AllowGet);
			}
			string requestUri = aIDomain + "/api/Setting/Index";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
			if (!result2.IsSuccessStatusCode)
			{
				return Json(new
				{
					model = aISettingViewModel,
					Message = Messages.msgErrorOperationFailed
				}, JsonRequestBehavior.AllowGet);
			}
			ServiceResult<AISettingViewModel> serviceResult = JsonConvert.DeserializeObject<ServiceResult<AISettingViewModel>>(result2.Content.ReadAsStringAsync().Result);
			if (serviceResult != null && serviceResult.Data != null)
			{
				aISettingViewModel = serviceResult.Data;
				base.ViewBag.AIModel = aISettingViewModel.DefModelName;
				base.ViewBag.FinalSystemPrompt = "فقط یک JSON object معتبر برگردان؛ بدون هیچ متن، توضیح، Markdown یا کاراکتر اضافی. خروجی باید مستقیما\u064b با { شروع و با } پایان یابد.\r\nبرای هر پرامپت، یک کلید عددی متوالی (1، 2، 3، ...) بساز. مقدار هر کلید باید شامل این فیلدها باشد:\r\n- prompt_id: شناسه پرامپت یا null\r\n- prompt_title: متن کامل پرامپت\r\n- answer: پاسخ کامل بر اساس داده\u200cها\r\n\r\nساختار:\r\n{\r\n  \"1\": {\r\n    \"prompt_id\": \"1\",\r\n    \"prompt_title\": \"متن کامل پرامپت\",\r\n    \"answer\": \"پاسخ کامل بر اساس داده\u200cها\"\r\n  }\r\n}";
				base.ViewBag.SystemPrompt = aISettingViewModel.DefSystemPrompt;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new
		{
			model = aISettingViewModel,
			Message = Messages.msgErrorOperationFailed
		}, JsonRequestBehavior.AllowGet);
	}

	public ActionResult GetUserCreditBalance()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		try
		{
			using HttpClient httpClient = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(800.0)
			};
			string aIDomain = SysSeting.Get().AIDomain;
			if (string.IsNullOrEmpty(aIDomain))
			{
				base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
				return View(new AIAnswerViewModel());
			}
			string content = JsonConvert.SerializeObject(new
			{
				LanguageId = lCID,
				UserId = UserLogin.CurrentUser.UserId
			});
			string requestUri = aIDomain + "/api/Response/GetUserCreditBalance";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			if (result <= 0)
			{
				result = 1065;
			}
			HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
			if (result2.IsSuccessStatusCode)
			{
				num = JsonConvert.DeserializeObject<ServiceResult<int>>(result2.Content.ReadAsStringAsync().Result).Data;
				if (num < 0)
				{
					num = 0;
				}
				base.ViewBag.UserCreditBalance = num;
				return Json(new
				{
					userCreditBalance = num
				}, JsonRequestBehavior.AllowGet);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new
		{
			userCreditBalance = num,
			Message = Messages.msgErrorOperationFailed
		}, JsonRequestBehavior.AllowGet);
	}
}
