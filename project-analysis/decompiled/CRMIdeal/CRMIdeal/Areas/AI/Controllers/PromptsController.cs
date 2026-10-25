using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Models.ViewModel.AI;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.AI.Controllers;

public class PromptsController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actAIPrompt")]
	public ActionResult Index(int promptGroupId = 0)
	{
		base.ViewBag.IsBuying = VersionBuyer.AI;
		base.ViewBag.PromptGroupId = promptGroupId;
		return View();
	}

	[HttpGet]
	public ActionResult GetPrompts(int promptGroupId = 0, int pageNumber = 1, int pageSize = 12)
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
				LanguageId = lCID
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
			string requestUri = aIDomain + "/api/Prompt/Index";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
			List<CRMspSelectUsers_Result> list = Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, 0));
			if (result2.IsSuccessStatusCode)
			{
				List<AIPromptViewModel> data = JsonConvert.DeserializeObject<ServiceResult<List<AIPromptViewModel>>>(result2.Content.ReadAsStringAsync().Result).Data;
				foreach (AIPromptViewModel item in data)
				{
					CRMspSelectUsers_Result cRMspSelectUsers_Result = ((list != null) ? Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u.UserId == item.FirstRegisterUserId)) : null);
					item.FirstRegisterUser = cRMspSelectUsers_Result?.LName + " " + cRMspSelectUsers_Result?.FName;
					CRMspSelectUsers_Result cRMspSelectUsers_Result2 = ((list != null) ? Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u.UserId == item.RegisterUserId)) : null);
					item.RegisterUser = cRMspSelectUsers_Result2?.LName + " " + cRMspSelectUsers_Result2?.FName;
					item.RegisterDateStr = (item.RegisterDate.HasValue ? DateTimeClass.GetLocalDate(item.RegisterDate).Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.FirstRegisterDateStr = (item.FirstRegisterDate.HasValue ? DateTimeClass.GetLocalDate(item.FirstRegisterDate).Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				}
				int? num = ((data != null && Enumerable.Any<AIPromptViewModel>((IEnumerable<AIPromptViewModel>)data)) ? data[0].TotalCount : new int?(0));
				return Json(new
				{
					Status = 1,
					Message = "",
					Data = new
					{
						Items = data,
						TotalCount = num,
						PageNumber = pageNumber,
						PageSize = pageSize,
						TotalPages = (int)Math.Ceiling((double)num.Value / (double)pageSize),
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
					Items = new List<AIPromptViewModel>(),
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

	[DynamicAuthorize(ControllerName = "frmAIPrompt", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int promptId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			AIPromptLanguageViewModel model = new AIPromptLanguageViewModel();
			if (promptId > 0)
			{
				using HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string content = JsonConvert.SerializeObject(new
				{
					PromptId = promptId,
					PageNumber = 1,
					PageSize = 1,
					LanguageId = lCID,
					UserId = UserLogin.CurrentUser.UserId
				});
				string aIDomain = SysSeting.Get().AIDomain;
				if (string.IsNullOrEmpty(aIDomain))
				{
					base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
					return View(model);
				}
				string requestUri = aIDomain + "/api/Prompt/Index";
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
				if (!result2.IsSuccessStatusCode)
				{
					base.ViewBag.Error = Messages.MsgErrorNotFound;
					return View(model);
				}
				ServiceResult<List<AIPromptLanguageViewModel>> serviceResult = JsonConvert.DeserializeObject<ServiceResult<List<AIPromptLanguageViewModel>>>(result2.Content.ReadAsStringAsync().Result);
				if (serviceResult != null && serviceResult.Data != null && Enumerable.Any<AIPromptLanguageViewModel>((IEnumerable<AIPromptLanguageViewModel>)serviceResult.Data))
				{
					AIPromptLanguageViewModel aIPromptLanguageViewModel = serviceResult.Data[0];
					model = new AIPromptLanguageViewModel
					{
						PrTitle = aIPromptLanguageViewModel.PrTitle,
						PromptId = promptId,
						PromptGroupId = aIPromptLanguageViewModel.PromptGroupId,
						OrderView = aIPromptLanguageViewModel.OrderView,
						PrSystemRole = aIPromptLanguageViewModel.PrSystemRole,
						PrDesc = aIPromptLanguageViewModel.PrDesc,
						PrData = aIPromptLanguageViewModel.PrData,
						PrIsDisabled = aIPromptLanguageViewModel.PrIsDisabled,
						PrData_Lang = aIPromptLanguageViewModel.PrData_Lang,
						PrDesc_Lang = aIPromptLanguageViewModel.PrDesc_Lang,
						PrSystemRole_Lang = aIPromptLanguageViewModel.PrSystemRole_Lang,
						PrTitle_Lang = aIPromptLanguageViewModel.PrTitle_Lang
					};
				}
			}
			List<AIPromptGroupViewModel> list = new List<AIPromptGroupViewModel>();
			using (HttpClient httpClient2 = new HttpClient())
			{
				httpClient2.DefaultRequestHeaders.Accept.Clear();
				httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string content3 = JsonConvert.SerializeObject(new
				{
					UserId = UserLogin.CurrentUser.UserId,
					LanguageId = lCID
				});
				string aIDomain2 = SysSeting.Get().AIDomain;
				if (string.IsNullOrEmpty(aIDomain2))
				{
					base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
					return View(model);
				}
				string requestUri2 = aIDomain2 + "/api/PromptGroup/GetAll";
				StringContent content4 = new StringContent(content3, Encoding.UTF8, "application/json");
				HttpResponseMessage result3 = httpClient2.PostAsync(requestUri2, content4).Result;
				if (result3.IsSuccessStatusCode)
				{
					list = Enumerable.ToList<AIPromptGroupViewModel>(Enumerable.Select<AIPromptGroupViewModel, AIPromptGroupViewModel>((IEnumerable<AIPromptGroupViewModel>)JsonConvert.DeserializeObject<ServiceResult<List<AIPromptGroupViewModel>>>(result3.Content.ReadAsStringAsync().Result).Data, (Func<AIPromptGroupViewModel, AIPromptGroupViewModel>)((AIPromptGroupViewModel pg) => new AIPromptGroupViewModel
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
			return View(model);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			AIPromptLanguageViewModel model2 = new AIPromptLanguageViewModel();
			base.ViewBag.Error = Messages.msgErrorOperationFailed;
			return View(model2);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmAIPromptDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(AIPromptLanguageViewModel model)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		new CommonResultViewModel<string>();
		DateTime now = DateTime.Now;
		now.ToString("yyyyMMdd", new PersianCulture());
		_ = UserLogin.CurrentUser.UserId;
		_ = Configuration.AppType;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		short.Parse(now.ToString("MM", new PersianCulture()));
		short.Parse(Financial.Get().Id.ToString());
		string text = "";
		try
		{
			if (base.ModelState.IsValid)
			{
				int num = 0;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.PrTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.PrTitle,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.PrData_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrData_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.PrData,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.PrDesc_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrDesc_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = model.PrDesc,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.PrSystemRole_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.PrSystemRole_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = model.PrSystemRole,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(model.PrTitle))
				{
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.Title) + "<br>";
					num++;
				}
				else if (!Public.CheckMultiLanguage(model.PrTitle, list))
				{
					num++;
				}
				if (string.IsNullOrEmpty(model.PrData))
				{
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.Prompt) + "<br>";
					num++;
				}
				else if (!Public.CheckMultiLanguage(model.PrData, list2))
				{
					num++;
				}
				if (model.PromptGroupId == 0)
				{
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.Group) + "<br>";
					num++;
				}
				if (!string.IsNullOrEmpty(model.PrDesc) && !Public.CheckMultiLanguage(model.PrDesc, list3))
				{
					num++;
				}
				if (!string.IsNullOrEmpty(model.PrSystemRole) && !Public.CheckMultiLanguage(model.PrSystemRole, list4))
				{
					num++;
				}
				if (!VersionBuyer.AI)
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuyAI;
					num++;
				}
				if (num == 0)
				{
					if (model.PromptId == 0)
					{
						using HttpClient httpClient = new HttpClient();
						httpClient.DefaultRequestHeaders.Accept.Clear();
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string content = JsonConvert.SerializeObject(new
						{
							TitleLangJson = new JavaScriptSerializer().Serialize((object)list),
							SystemRoleLangJson = new JavaScriptSerializer().Serialize((object)list4),
							DescLangJson = new JavaScriptSerializer().Serialize((object)list3),
							DataLangJson = new JavaScriptSerializer().Serialize((object)list2),
							PrIsDisabled = model.PrIsDisabled,
							PromptGroupId = model.PromptGroupId,
							OrderView = model.OrderView,
							LanguageId = lCID,
							UserId = UserLogin.CurrentUser.UserId
						});
						string aIDomain = SysSeting.Get().AIDomain;
						if (string.IsNullOrEmpty(aIDomain))
						{
							base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
							return View(model);
						}
						string requestUri = aIDomain + "/api/Prompt/Insert";
						StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
						if (!result2.IsSuccessStatusCode)
						{
							base.ViewBag.Error = Messages.msgErrorOperationFailed;
							return View(model);
						}
						ServiceResult<int> serviceResult = JsonConvert.DeserializeObject<ServiceResult<int>>(result2.Content.ReadAsStringAsync().Result);
						if (serviceResult == null || serviceResult.Data == 0)
						{
							base.ViewBag.Error = serviceResult.Message;
							return View(model);
						}
						_ = serviceResult.Data;
					}
					else
					{
						using HttpClient httpClient2 = new HttpClient();
						httpClient2.DefaultRequestHeaders.Accept.Clear();
						httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string content3 = JsonConvert.SerializeObject(new
						{
							PromptId = model.PromptId,
							TitleLangJson = new JavaScriptSerializer().Serialize((object)list),
							SystemRoleLangJson = new JavaScriptSerializer().Serialize((object)list4),
							DescLangJson = new JavaScriptSerializer().Serialize((object)list3),
							DataLangJson = new JavaScriptSerializer().Serialize((object)list2),
							PrIsDisabled = model.PrIsDisabled,
							PromptGroupId = model.PromptGroupId,
							OrderView = model.OrderView,
							LanguageId = lCID,
							UserId = UserLogin.CurrentUser.UserId
						});
						string aIDomain2 = SysSeting.Get().AIDomain;
						if (string.IsNullOrEmpty(aIDomain2))
						{
							base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
							return View(model);
						}
						string requestUri2 = aIDomain2 + "/api/Prompt/Update";
						StringContent content4 = new StringContent(content3, Encoding.UTF8, "application/json");
						HttpResponseMessage result3 = httpClient2.PostAsync(requestUri2, content4).Result;
						if (!result3.IsSuccessStatusCode)
						{
							base.ViewBag.Error = Messages.msgErrorOperationFailed;
							return View(model);
						}
						ServiceResult<bool> serviceResult2 = JsonConvert.DeserializeObject<ServiceResult<bool>>(result3.Content.ReadAsStringAsync().Result);
						if (serviceResult2 == null || !serviceResult2.Data)
						{
							base.ViewBag.Error = serviceResult2.Message;
						}
					}
					base.ViewBag.Successfull = Messages.msgSuccessAction;
					return View(model);
				}
			}
			if (text != "")
			{
				base.ViewBag.Error = text;
			}
			return View(model);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
			return View(model);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmAIPrompt", ActionName = "actDelete")]
	public ActionResult Delete(int promptId)
	{
		CommonResultViewModel<string> data = new CommonResultViewModel<string>();
		try
		{
			if (promptId > 0)
			{
				using HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				string content = JsonConvert.SerializeObject(new
				{
					PromptId = promptId,
					LanguageId = lCID,
					UserId = UserLogin.CurrentUser.UserId
				});
				string aIDomain = SysSeting.Get().AIDomain;
				if (string.IsNullOrEmpty(aIDomain))
				{
					data = new CommonResultViewModel<string>
					{
						Data = "",
						Message = Messages.msgErrorAIDomainNotFound,
						Status = CommonResultStatusViewModel.Error
					};
				}
				string requestUri = aIDomain + "/api/Prompt/Delete";
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content2).Result;
				if (result.IsSuccessStatusCode)
				{
					ServiceResult<bool> serviceResult = JsonConvert.DeserializeObject<ServiceResult<bool>>(result.Content.ReadAsStringAsync().Result);
					data = ((serviceResult == null || !serviceResult.Data) ? new CommonResultViewModel<string>
					{
						Data = "",
						Message = serviceResult.Message,
						Status = CommonResultStatusViewModel.Error
					} : new CommonResultViewModel<string>
					{
						Data = "",
						Message = "",
						Status = CommonResultStatusViewModel.Success
					});
				}
				else
				{
					data = new CommonResultViewModel<string>
					{
						Data = "",
						Message = Messages.msgErrorOperationFailed,
						Status = CommonResultStatusViewModel.Error
					};
				}
			}
			else
			{
				data = new CommonResultViewModel<string>
				{
					Data = "",
					Message = Messages.ErrorNotFound,
					Status = CommonResultStatusViewModel.Error
				};
			}
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = new CommonResultViewModel<string>
			{
				Data = "",
				Message = Messages.msgErrorOperationFailed,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
	}
}
