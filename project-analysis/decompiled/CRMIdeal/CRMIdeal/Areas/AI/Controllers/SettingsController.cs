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

public class SettingsController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actAISetting")]
	public ActionResult Index()
	{
		base.ViewBag.IsBuying = VersionBuyer.AI;
		return View();
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
					Message = Messages.MsgErrorNotFound
				}, JsonRequestBehavior.AllowGet);
			}
			ServiceResult<AISettingViewModel> serviceResult = JsonConvert.DeserializeObject<ServiceResult<AISettingViewModel>>(result2.Content.ReadAsStringAsync().Result);
			if (serviceResult != null && serviceResult.Data != null)
			{
				aISettingViewModel = serviceResult.Data;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.MsgErrorNotFound;
			return Json(aISettingViewModel, JsonRequestBehavior.AllowGet);
		}
		return Json(aISettingViewModel, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmAISetting", ActionName = "actEdit")]
	public ActionResult InsertEdit()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		AISettingLanguageViewModel model = new AISettingLanguageViewModel();
		try
		{
			using (HttpClient httpClient = new HttpClient())
			{
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
					base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
					return View(model);
				}
				string requestUri = aIDomain + "/api/Setting/Index";
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
				if (!result2.IsSuccessStatusCode)
				{
					base.ViewBag.Error = Messages.MsgErrorNotFound;
					return View(model);
				}
				ServiceResult<AISettingLanguageViewModel> serviceResult = JsonConvert.DeserializeObject<ServiceResult<AISettingLanguageViewModel>>(result2.Content.ReadAsStringAsync().Result);
				if (serviceResult != null && serviceResult.Data != null)
				{
					model = serviceResult.Data;
				}
			}
			List<AIProviderViewModel> list = new List<AIProviderViewModel>();
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
				string requestUri2 = aIDomain2 + "/api/Provider/GetAll";
				StringContent content4 = new StringContent(content3, Encoding.UTF8, "application/json");
				HttpResponseMessage result3 = httpClient2.PostAsync(requestUri2, content4).Result;
				if (result3.IsSuccessStatusCode)
				{
					list = Enumerable.ToList<AIProviderViewModel>(Enumerable.Select<AIProviderViewModel, AIProviderViewModel>((IEnumerable<AIProviderViewModel>)JsonConvert.DeserializeObject<ServiceResult<List<AIProviderViewModel>>>(result3.Content.ReadAsStringAsync().Result).Data, (Func<AIProviderViewModel, AIProviderViewModel>)((AIProviderViewModel pv) => new AIProviderViewModel
					{
						ProviderId = pv.ProviderId,
						ProviderName = pv.ProviderName
					})));
					base.ViewBag.Providers = Enumerable.ToList<SelectListItem>(Enumerable.Select<AIProviderViewModel, SelectListItem>((IEnumerable<AIProviderViewModel>)list, (Func<AIProviderViewModel, SelectListItem>)((AIProviderViewModel p) => new SelectListItem
					{
						Value = p.ProviderId.ToString(),
						Text = p.ProviderName
					})));
				}
			}
			List<AIModelViewModel> list2 = new List<AIModelViewModel>();
			using HttpClient httpClient3 = new HttpClient();
			httpClient3.DefaultRequestHeaders.Accept.Clear();
			httpClient3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string content5 = JsonConvert.SerializeObject(new
			{
				UserId = UserLogin.CurrentUser.UserId,
				LanguageId = lCID
			});
			string aIDomain3 = SysSeting.Get().AIDomain;
			if (string.IsNullOrEmpty(aIDomain3))
			{
				base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
				return View(model);
			}
			string requestUri3 = aIDomain3 + "/api/Model/GetAll";
			StringContent content6 = new StringContent(content5, Encoding.UTF8, "application/json");
			HttpResponseMessage result4 = httpClient3.PostAsync(requestUri3, content6).Result;
			if (result4.IsSuccessStatusCode)
			{
				list2 = Enumerable.ToList<AIModelViewModel>(Enumerable.Select<AIModelViewModel, AIModelViewModel>((IEnumerable<AIModelViewModel>)JsonConvert.DeserializeObject<ServiceResult<List<AIModelViewModel>>>(result4.Content.ReadAsStringAsync().Result).Data, (Func<AIModelViewModel, AIModelViewModel>)((AIModelViewModel m) => new AIModelViewModel
				{
					ModelId = m.ModelId,
					ModelName = m.ModelName
				})));
				base.ViewBag.Models = Enumerable.ToList<SelectListItem>(Enumerable.Select<AIModelViewModel, SelectListItem>((IEnumerable<AIModelViewModel>)list2, (Func<AIModelViewModel, SelectListItem>)((AIModelViewModel m) => new SelectListItem
				{
					Value = m.ModelId.ToString(),
					Text = m.ModelName
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.MsgErrorNotFound;
			return View(model);
		}
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmAISetting", ActionName = "actPost")]
	public ActionResult InsertEdit(AISettingLanguageViewModel model)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
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
				if (!string.IsNullOrEmpty(model.DefSystemPrompt_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.DefSystemPrompt_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.DefSystemPrompt,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(model.DefSystemPrompt))
				{
					text = text + string.Format(Messages.ErrorFieldEmpty, Labels.SystemPrompt) + "<br>";
					num++;
				}
				else if (!Public.CheckMultiLanguage(model.DefSystemPrompt, list))
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
					using (HttpClient httpClient = new HttpClient())
					{
						httpClient.DefaultRequestHeaders.Accept.Clear();
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string content = JsonConvert.SerializeObject(new
						{
							DefSystemPromptLangJson = new JavaScriptSerializer().Serialize((object)list),
							DefModelId = model.DefModelId,
							DefProviderId = model.DefProviderId,
							DefTemperature = model.DefTemperature,
							DefMaxTokens = model.DefMaxTokens,
							ProviderTimeOut = model.ProviderTimeOut,
							MinRequestTokenBalance = model.MinRequestTokenBalance,
							UserId = UserLogin.CurrentUser.UserId
						});
						string aIDomain = SysSeting.Get().AIDomain;
						if (string.IsNullOrEmpty(aIDomain))
						{
							base.ViewBag.Error = Messages.msgErrorAIDomainNotFound;
							return View(model);
						}
						string requestUri = aIDomain + "/api/Setting/InsertOrUpdate";
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
}
