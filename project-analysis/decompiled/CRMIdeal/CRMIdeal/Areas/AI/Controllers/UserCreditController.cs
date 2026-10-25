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
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.AI.Controllers;

public class UserCreditController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actAIUserCredit")]
	public ActionResult Index()
	{
		base.ViewBag.IsBuying = VersionBuyer.AI;
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			List<CRMspSelectActiveUsers_Result> list = CRMIdeal.Classes.Helper.User.SelectActiveUsers(result);
			base.ViewBag.Users = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result u) => new SelectListItem
			{
				Value = u.UserId.ToString(),
				Text = u.LName + " " + u.FName
			})));
		}
		catch (Exception)
		{
			throw;
		}
		return View();
	}

	[HttpGet]
	public ActionResult GetUserCredits(int pageNumber = 1, int pageSize = 12, int? creditUserId = null)
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
				UserCreditId = 0,
				CreditUserId = creditUserId,
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
			string requestUri = aIDomain + "/api/UserCredit/Index";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
			List<CRMspSelectUsers_Result> list = Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, 0));
			if (result2.IsSuccessStatusCode)
			{
				List<AIUserCreditViewModel> data = JsonConvert.DeserializeObject<ServiceResult<List<AIUserCreditViewModel>>>(result2.Content.ReadAsStringAsync().Result).Data;
				foreach (AIUserCreditViewModel item in data)
				{
					CRMspSelectUsers_Result cRMspSelectUsers_Result = ((list != null) ? Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u.UserId == item.CreditUserId)) : null);
					item.CreditUser = cRMspSelectUsers_Result?.LName + " " + cRMspSelectUsers_Result?.FName;
					CRMspSelectUsers_Result cRMspSelectUsers_Result2 = ((list != null) ? Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u.UserId == item.FirstRegisterUserId)) : null);
					item.FirstRegisterUser = cRMspSelectUsers_Result2?.LName + " " + cRMspSelectUsers_Result2?.FName;
					CRMspSelectUsers_Result cRMspSelectUsers_Result3 = ((list != null) ? Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u.UserId == item.RegisterUserId)) : null);
					item.RegisterUser = cRMspSelectUsers_Result3?.LName + " " + cRMspSelectUsers_Result3?.FName;
					item.ExpiryDateStr = (item.ExpiryDate.HasValue ? DateTimeClass.GetLocalDate(item.ExpiryDate).Value.ToString("yyyy/MM/dd") : "");
					item.RegisterDateStr = (item.RegisterDate.HasValue ? DateTimeClass.GetLocalDate(item.RegisterDate).Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.FirstRegisterDateStr = (item.FirstRegisterDate.HasValue ? DateTimeClass.GetLocalDate(item.FirstRegisterDate).Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				}
				int? num = ((data != null && Enumerable.Any<AIUserCreditViewModel>((IEnumerable<AIUserCreditViewModel>)data)) ? data[0].TotalCount : new int?(0));
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
					Items = new List<AIUserCreditViewModel>(),
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
					Items = new List<AIUserCreditViewModel>(),
					TotalCount = 0,
					PageNumber = pageNumber,
					PageSize = pageSize,
					TotalPages = 0,
					HasNextPage = false
				}
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[DynamicAuthorize(ControllerName = "frmAIUserCredit", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int userCreditId = 0, int? creditUserId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			AIUserCreditLanguageViewModel aIUserCreditLanguageViewModel = new AIUserCreditLanguageViewModel();
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectActiveUsers_Result> list = CRMIdeal.Classes.Helper.User.SelectActiveUsers(result2);
			base.ViewBag.Users = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result u) => new SelectListItem
			{
				Value = u.UserId.ToString(),
				Text = u.LName + " " + u.FName
			})));
			if (creditUserId.HasValue && creditUserId.Value > 0)
			{
				aIUserCreditLanguageViewModel.CreditUserId = creditUserId.Value;
			}
			if (userCreditId > 0)
			{
				using HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string content = JsonConvert.SerializeObject(new
				{
					UserCreditId = userCreditId,
					PageNumber = 1,
					PageSize = 1,
					LanguageId = lCID,
					UserId = UserLogin.CurrentUser.UserId
				});
				string aIDomain = SysSeting.Get().AIDomain;
				if (string.IsNullOrEmpty(aIDomain))
				{
					base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
					return View(aIUserCreditLanguageViewModel);
				}
				string requestUri = aIDomain + "/api/UserCredit/Index";
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result3 = httpClient.PostAsync(requestUri, content2).Result;
				if (!result3.IsSuccessStatusCode)
				{
					base.ViewBag.Error = Messages.MsgErrorNotFound;
					return View(aIUserCreditLanguageViewModel);
				}
				ServiceResult<List<AIUserCreditLanguageViewModel>> serviceResult = JsonConvert.DeserializeObject<ServiceResult<List<AIUserCreditLanguageViewModel>>>(result3.Content.ReadAsStringAsync().Result);
				if (serviceResult != null && serviceResult.Data != null && Enumerable.Any<AIUserCreditLanguageViewModel>((IEnumerable<AIUserCreditLanguageViewModel>)serviceResult.Data))
				{
					AIUserCreditLanguageViewModel aIUserCreditLanguageViewModel2 = serviceResult.Data[0];
					aIUserCreditLanguageViewModel = new AIUserCreditLanguageViewModel
					{
						Description = aIUserCreditLanguageViewModel2.Description,
						Description_Lang = aIUserCreditLanguageViewModel2.Description_Lang,
						CreditToken = aIUserCreditLanguageViewModel2.CreditToken,
						CreditUserId = aIUserCreditLanguageViewModel2.CreditUserId,
						ExpiryDay = aIUserCreditLanguageViewModel2.ExpiryDay,
						LanguageId = aIUserCreditLanguageViewModel2.LanguageId,
						UserCreditId = aIUserCreditLanguageViewModel2.UserCreditId
					};
				}
			}
			return View(aIUserCreditLanguageViewModel);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			AIUserCreditLanguageViewModel model = new AIUserCreditLanguageViewModel();
			base.ViewBag.Error = Messages.msgErrorOperationFailed;
			return View(model);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmAIUserCreditDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(AIUserCreditLanguageViewModel model)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
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
				if (!string.IsNullOrEmpty(model.Description_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Description_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Description,
					LanguageId = lCID
				});
				if (!VersionBuyer.AI)
				{
					text = "BV|" + Messages.VersionBuyAI;
					num++;
				}
				if (model.CreditToken == 0)
				{
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.TokenAmount) + "<br>";
					num++;
				}
				if (model.CreditUserId == 0)
				{
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.User) + "<br>";
					num++;
				}
				model.ExpiryDay = null;
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				List<CRMspSelectActiveUsers_Result> list2 = CRMIdeal.Classes.Helper.User.SelectActiveUsers(result2);
				base.ViewBag.Users = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result u) => new SelectListItem
				{
					Value = u.UserId.ToString(),
					Text = u.LName + " " + u.FName
				})));
				if (num == 0)
				{
					if (model.UserCreditId == 0)
					{
						using HttpClient httpClient = new HttpClient();
						httpClient.DefaultRequestHeaders.Accept.Clear();
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string content = JsonConvert.SerializeObject(new
						{
							CreditUserId = model.CreditUserId,
							CreditToken = model.CreditToken,
							ExpiryDay = model.ExpiryDay,
							DescriptionLangJson = new JavaScriptSerializer().Serialize((object)list),
							LanguageId = lCID,
							UserId = UserLogin.CurrentUser.UserId
						});
						string aIDomain = SysSeting.Get().AIDomain;
						if (string.IsNullOrEmpty(aIDomain))
						{
							base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
							return View(model);
						}
						string requestUri = aIDomain + "/api/UserCredit/Insert";
						StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
						HttpResponseMessage result3 = httpClient.PostAsync(requestUri, content2).Result;
						if (!result3.IsSuccessStatusCode)
						{
							base.ViewBag.Error = Messages.msgErrorOperationFailed;
							return View(model);
						}
						ServiceResult<int> serviceResult = JsonConvert.DeserializeObject<ServiceResult<int>>(result3.Content.ReadAsStringAsync().Result);
						if (serviceResult == null || serviceResult.Data == 0)
						{
							base.ViewBag.Error = serviceResult.Message;
							return View(model);
						}
						_ = serviceResult.Data;
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
	[DynamicAuthorize(ControllerName = "frmAIPromptGroup", ActionName = "actDelete")]
	public ActionResult Delete(int userCreditId)
	{
		CommonResultViewModel<string> data = new CommonResultViewModel<string>();
		try
		{
			if (userCreditId > 0)
			{
				using HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				string content = JsonConvert.SerializeObject(new
				{
					UserCreditId = userCreditId,
					LanguageId = lCID,
					UserId = UserLogin.CurrentUser.UserId
				});
				string aIDomain = SysSeting.Get().AIDomain;
				if (string.IsNullOrEmpty(aIDomain))
				{
					return Json(new
					{
						Status = 0,
						Message = Messages.msgErrorAIDomainNotFound
					}, JsonRequestBehavior.AllowGet);
				}
				string requestUri = aIDomain + "/api/UserCredit/Delete";
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
			return Json(new CommonResultViewModel<string>
			{
				Data = "",
				Message = Messages.msgErrorOperationFailed,
				Status = CommonResultStatusViewModel.Error
			}, JsonRequestBehavior.AllowGet);
		}
	}
}
