using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using Mobile.Cache;
using Mobile.Cache.MobUser;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.Models;

namespace Mobile.Controllers;

public class MobAccountController : Controller
{
	private CRMEntities _db = new CRMEntities();

	public ActionResult Login(string ReturnUrl = "")
	{
		string text = "";
		MobLoginViewModel mobLoginViewModel = new MobLoginViewModel();
		try
		{
			text = (mobLoginViewModel.MainCaptchaCode = new RandomText().CreateRandomCode(5, WithNumber: true));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CaptchaCode = text;
		return View(mobLoginViewModel);
	}

	[HttpPost]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
	public ActionResult Login(MobLoginViewModel model, string ReturnUrl)
	{
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		string text = "";
		string text2 = "";
		try
		{
			text = new RandomText().CreateRandomCode(5, WithNumber: true);
			if (string.IsNullOrEmpty(model.CaptchaCode) || string.IsNullOrEmpty(model.MainCaptchaCode))
			{
				text2 = Messages.MobMsgErrorAllInfoWebSetting;
			}
			else
			{
				string text3 = model.CaptchaCode.Trim().ToLower();
				string text4 = model.MainCaptchaCode.Trim().ToLower();
				text4 = text4.Trim();
				text4 = text4.Replace(" ", "");
				if (text3 != text4)
				{
					text2 = Messages.MobMsgErrorInvalidCaptcha;
				}
				else if (base.ModelState.IsValid)
				{
					DateTime now = DateTime.Now;
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
					int value = 1065;
					string userPassword = new BaseInfo().ConvertMd5(model.Password).ToLower();
					MobspLoadUserLoginInfo_Result mobspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<MobspLoadUserLoginInfo_Result>((IEnumerable<MobspLoadUserLoginInfo_Result>)_db.MobspLoadUserLoginInfo(0, model.UserName, userPassword, value, result));
					if (mobspLoadUserLoginInfo_Result != null)
					{
						int num = 20;
						UserLoginInfo currentUser = MobUserLogin.CurrentUser;
						if (currentUser != null)
						{
							Info.Clear(currentUser.UserId);
						}
						FormsAuthenticationTicket val = new FormsAuthenticationTicket(mobspLoadUserLoginInfo_Result.UserId.ToString(), false, num);
						Info.Update(mobspLoadUserLoginInfo_Result.UserId, true);
						Manager.UpdateAllSettingCach();
						string text5 = FormsAuthentication.Encrypt(val);
						HttpCookie val2 = new HttpCookie(FormsAuthentication.FormsCookieName, text5);
						val2.Expires = now.AddMinutes(num);
						val2.HttpOnly = true;
						base.Response.Cookies.Add(val2);
						if (!string.IsNullOrEmpty(ReturnUrl))
						{
							return Redirect(ReturnUrl);
						}
						return Redirect(FormsAuthentication.DefaultUrl);
					}
					text2 = Messages.MobMsgErrorUsernamePasswordIncorrect;
				}
				else
				{
					text2 = Messages.MobMsgErrorUsernamePasswordIncorrect;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CaptchaCode = text;
		model.MainCaptchaCode = text;
		base.ViewBag.Error = text2;
		base.ViewBag.ReturnUrl = ReturnUrl;
		return View(model);
	}

	public ActionResult Logout()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Logoff()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		if (base.HttpContext.User != null)
		{
			Manager.ClearAllMobUserCach();
		}
		base.Response.Cookies.Clear();
		FormsAuthentication.SignOut();
		base.HttpContext.User = (IPrincipal)new GenericPrincipal((IIdentity)new GenericIdentity(string.Empty), (string[])null);
		Thread.CurrentPrincipal = null;
		HttpCookie val = new HttpCookie(FormsAuthentication.FormsCookieName, "");
		val.Expires = DateTime.Now.AddYears(-1);
		base.Response.Cookies.Add(val);
		HttpCookie val2 = new HttpCookie("ASP.NET_SessionId", "");
		val2.Expires = DateTime.Now.AddYears(-1);
		base.Response.Cookies.Add(val2);
		base.Session.Clear();
		base.Session.Abandon();
		base.Response.Cache.SetExpires(DateTime.Now.AddYears(-1));
		base.Response.Cache.SetCacheability((HttpCacheability)1);
		FormsAuthentication.RedirectToLoginPage();
		return RedirectToAction("Login", "MobAccount", (object)new
		{
			area = "",
			d = DateTime.Now
		});
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
