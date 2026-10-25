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

public class ProvidersController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actAIProvider")]
	public ActionResult Index()
	{
		base.ViewBag.IsBuying = VersionBuyer.AI;
		return View();
	}

	[HttpGet]
	public ActionResult GetProviders(int pageNumber = 1, int pageSize = 12)
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
			string requestUri = aIDomain + "/api/Provider/Index";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
			List<CRMspSelectUsers_Result> list = Enumerable.ToList<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)db.CRMspSelectUsers(lCID, result, 0));
			if (result2.IsSuccessStatusCode)
			{
				List<AIProviderViewModel> data = JsonConvert.DeserializeObject<ServiceResult<List<AIProviderViewModel>>>(result2.Content.ReadAsStringAsync().Result).Data;
				foreach (AIProviderViewModel item in data)
				{
					CRMspSelectUsers_Result cRMspSelectUsers_Result = ((list != null) ? Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u.UserId == item.FirstRegisterUserId)) : null);
					item.FirstRegisterUser = cRMspSelectUsers_Result?.LName + " " + cRMspSelectUsers_Result?.FName;
					CRMspSelectUsers_Result cRMspSelectUsers_Result2 = ((list != null) ? Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u.UserId == item.RegisterUserId)) : null);
					item.RegisterUser = cRMspSelectUsers_Result2?.LName + " " + cRMspSelectUsers_Result2?.FName;
					item.RegisterDateStr = (item.RegisterDate.HasValue ? DateTimeClass.GetLocalDate(item.RegisterDate).Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.FirstRegisterDateStr = (item.FirstRegisterDate.HasValue ? DateTimeClass.GetLocalDate(item.FirstRegisterDate).Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				}
				int? num = ((data != null && Enumerable.Any<AIProviderViewModel>((IEnumerable<AIProviderViewModel>)data)) ? data[0].TotalCount : new int?(0));
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
					Items = new List<AIProviderViewModel>(),
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
					Items = new List<AIProviderViewModel>(),
					TotalCount = 0,
					PageNumber = pageNumber,
					PageSize = pageSize,
					TotalPages = 0,
					HasNextPage = false
				}
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[DynamicAuthorize(ControllerName = "frmAIProvider", ActionName = "actEdit")]
	public ActionResult InsertEdit(int providerId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			AIProviderLanguageViewModel model = new AIProviderLanguageViewModel();
			if (providerId > 0)
			{
				using HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string content = JsonConvert.SerializeObject(new
				{
					ProviderId = providerId,
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
				string requestUri = aIDomain + "/api/Provider/Index";
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
				if (!result2.IsSuccessStatusCode)
				{
					base.ViewBag.Error = Messages.MsgErrorNotFound;
					return View(model);
				}
				ServiceResult<List<AIProviderLanguageViewModel>> serviceResult = JsonConvert.DeserializeObject<ServiceResult<List<AIProviderLanguageViewModel>>>(result2.Content.ReadAsStringAsync().Result);
				if (serviceResult != null && serviceResult.Data != null && Enumerable.Any<AIProviderLanguageViewModel>((IEnumerable<AIProviderLanguageViewModel>)serviceResult.Data))
				{
					AIProviderLanguageViewModel aIProviderLanguageViewModel = serviceResult.Data[0];
					aIProviderLanguageViewModel.ApiKey = "";
					model = new AIProviderLanguageViewModel
					{
						ProviderName = aIProviderLanguageViewModel.ProviderName,
						ProviderName_Lang = aIProviderLanguageViewModel.ProviderName_Lang,
						ApiBaseUrl = aIProviderLanguageViewModel.ApiBaseUrl,
						ProviderId = aIProviderLanguageViewModel.ProviderId
					};
				}
			}
			return View(model);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			AIProviderLanguageViewModel model2 = new AIProviderLanguageViewModel();
			base.ViewBag.Error = Messages.msgErrorOperationFailed;
			return View(model2);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmAIProviderDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(AIProviderLanguageViewModel model)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
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
				if (!string.IsNullOrEmpty(model.ProviderName_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.ProviderName_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.ProviderName,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(model.ProviderName))
				{
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.Name) + "<br>";
					num++;
				}
				else if (!Public.CheckMultiLanguage(model.ProviderName, list))
				{
					num++;
				}
				if (!IsUrl(model.ApiBaseUrl))
				{
					text = text + Messages.msgInvalidUrlAddress + "<br>";
					num++;
				}
				if (!VersionBuyer.AI)
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuyAI;
					num++;
				}
				if (num == 0)
				{
					if (model.ProviderId == 0)
					{
						using HttpClient httpClient = new HttpClient();
						httpClient.DefaultRequestHeaders.Accept.Clear();
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string content = JsonConvert.SerializeObject(new
						{
							TitleLangJson = new JavaScriptSerializer().Serialize((object)list),
							LanguageId = lCID,
							UserId = UserLogin.CurrentUser.UserId
						});
						string aIDomain = SysSeting.Get().AIDomain;
						if (string.IsNullOrEmpty(aIDomain))
						{
							base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
							return View(model);
						}
						string requestUri = aIDomain + "/api/Provider/Insert";
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
							ProviderNameLangJson = new JavaScriptSerializer().Serialize((object)list),
							ApiKey = model.ApiKey,
							ApiBaseUrl = model.ApiBaseUrl,
							ProviderId = model.ProviderId,
							LanguageId = lCID,
							UserId = UserLogin.CurrentUser.UserId
						});
						string aIDomain2 = SysSeting.Get().AIDomain;
						if (string.IsNullOrEmpty(aIDomain2))
						{
							base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
							return View(model);
						}
						string requestUri2 = aIDomain2 + "/api/Provider/Update";
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

	private static bool IsUrl(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		if (Uri.TryCreate(text, UriKind.Absolute, out Uri result))
		{
			if (!(result.Scheme == Uri.UriSchemeHttp))
			{
				return result.Scheme == Uri.UriSchemeHttps;
			}
			return true;
		}
		return false;
	}
}
