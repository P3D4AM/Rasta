using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Controllers;

public class FoLoginOtherSysController : Controller
{
	[System.Web.Http.HttpGet]
	public async Task<ActionResult> LoginUrl(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		HttpClient httpClient = new HttpClient();
		CRMEntities db = null;
		string text = "";
		string text2 = "";
		try
		{
			db = new CRMEntities();
			MobspSelectCrmFoSetting_Result mobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmFoSetting_Result>((IEnumerable<MobspSelectCrmFoSetting_Result>)db.MobspSelectCrmFoSetting(result, result2, cId, null));
			if (mobspSelectCrmFoSetting_Result != null)
			{
				string loginAuthenticationInfoJson = mobspSelectCrmFoSetting_Result.LoginAuthenticationInfoJson;
				if (loginAuthenticationInfoJson != null)
				{
					List<FoLoginAuthentication> list = new JavaScriptSerializer().Deserialize<List<FoLoginAuthentication>>(loginAuthenticationInfoJson);
					text2 = list[2].Value + "?token=" + list[0].Value + "&callback=" + list[4].Value + "/FoLoginOtherSys/LoginUrlCallBack";
				}
			}
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			if (text2 != "")
			{
				HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(text2);
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string text3 = await httpResponseMessage.Content.ReadAsStringAsync();
					if (Enumerable.Any<char>((IEnumerable<char>)text3))
					{
						Dictionary<string, object> dictionary = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(text3);
						string text4 = (dynamic)dictionary["verify_url"];
						if (Enumerable.Any<char>((IEnumerable<char>)text4))
						{
							return Redirect(text4);
						}
						text = Messages.msgErrorOpenFoAuthentication;
					}
					else
					{
						text = Messages.ErrorFindInformation;
					}
				}
				else
				{
					text = Messages.msgErrorFoLoginCall;
				}
			}
			else
			{
				text = Messages.msgErrorFoLoginCall;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			httpClient.Dispose();
			db?.Dispose();
		}
		if (text != "")
		{
			return Redirect("~/MobErrorLogs/LoginError?msgStr=" + text);
		}
		return View();
	}

	[System.Web.Http.HttpGet]
	public async Task<ActionResult> LoginUrlCallBack(string jwt = "", int? ln = null, int? cId = null)
	{
		int result2 = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result2);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
		HttpClient httpClient = new HttpClient();
		CRMEntities db = null;
		string text = "";
		string domain = "";
		string value = "";
		string pwaUrl = "";
		string text2 = "";
		try
		{
			db = new CRMEntities();
			MobspSelectCrmFoSetting_Result mobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmFoSetting_Result>((IEnumerable<MobspSelectCrmFoSetting_Result>)db.MobspSelectCrmFoSetting(result2, result3, cId, null));
			if (mobspSelectCrmFoSetting_Result != null)
			{
				string loginAuthenticationInfoJson = mobspSelectCrmFoSetting_Result.LoginAuthenticationInfoJson;
				if (loginAuthenticationInfoJson != null)
				{
					List<FoLoginAuthentication> list = new JavaScriptSerializer().Deserialize<List<FoLoginAuthentication>>(loginAuthenticationInfoJson);
					text2 = list[3].Value;
					value = list[1].Value;
					pwaUrl = list[5].Value;
					domain = list[6].Value;
				}
			}
			if ((text2 != "") & (jwt != ""))
			{
				httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
				httpClient.DefaultRequestHeaders.Add("X-API-Key", value);
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
				HttpResponseMessage result = await httpClient.GetAsync(text2);
				string text3 = await result.Content.ReadAsStringAsync();
				if (Enumerable.Any<char>((IEnumerable<char>)text3))
				{
					Dictionary<string, object> dictionary = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(text3);
					if (result.IsSuccessStatusCode)
					{
						string text4 = ((dynamic)dictionary["data"])["phone"] ?? "0";
						if (text4 != "0")
						{
							if (pwaUrl == "")
							{
								text = Messages.msgErrorFoPwaUrlNotFinde;
								return Redirect("~/MobErrorLogs/LoginError?msgStr=" + text);
							}
							if (domain == "")
							{
								text = Messages.msgErrorFoDomainNotFinde;
								return Redirect("~/MobErrorLogs/LoginError?msgStr=" + text);
							}
							string url = pwaUrl + "?domain=" + domain + "&mobile=" + text4;
							return Redirect(url);
						}
						text = Messages.MobMsgNotFountCmpMobile;
					}
					else
					{
						text = Messages.msgErrorFoLoginCall;
					}
				}
				else
				{
					text = Messages.ErrorFindInformation;
				}
			}
			else
			{
				text = Messages.msgErrorFoLoginCall;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			httpClient.Dispose();
			db?.Dispose();
		}
		if (text != null)
		{
			return Redirect("~/MobErrorLogs/LoginError?msgStr=" + text);
		}
		return View();
	}
}
