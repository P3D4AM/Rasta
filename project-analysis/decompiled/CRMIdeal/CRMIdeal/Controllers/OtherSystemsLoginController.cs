using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CRM.Models;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Microsoft.Owin.Security;

namespace CRMIdeal.Controllers;

public class OtherSystemsLoginController : Controller
{
	public void KaramadLogin()
	{
		if (base.Request.IsAuthenticated)
		{
			base.Response.Redirect(FormsAuthentication.DefaultUrl);
			return;
		}
		base.HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
		{
			RedirectUri = "/"
		}, "KaramadSSO");
		base.Response.StatusCode = 401;
	}

	[KaramadAuthorize]
	public ActionResult KaramadLoginAuth(string ReturnUrl = "")
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		if (!base.Request.IsAuthenticated)
		{
			base.HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
			{
				RedirectUri = base.HttpContext.Request.RawUrl
			}, "KaramadSSO");
			return new HttpUnauthorizedResult();
		}
		ClaimsPrincipal user = base.HttpContext.GetOwinContext().Authentication.User;
		if (user.Identity.IsAuthenticated)
		{
			Claim val = Enumerable.FirstOrDefault<Claim>((IEnumerable<Claim>)Enumerable.ToList<Claim>(new ClaimsIdentity(user.Identity).Claims), (Func<Claim, bool>)((Claim x) => x.Type == "preferred_username"));
			if (val != null)
			{
				string text = val.Value ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					LoginViewModel loginViewModel = new LoginViewModel();
					loginViewModel.UserName = text;
					loginViewModel.SendFromAdmin = "";
					loginViewModel.LoginAuthType = 3;
					if (base.Request.Cookies["LoginType"] != null)
					{
						base.Request.Cookies.Remove("LoginType");
					}
					HttpCookie val2 = new HttpCookie("LoginType", 3.ToString());
					val2.Expires = DateTime.Now.AddMinutes(Configuration.CacheDefaultTimeInMinutes);
					base.Response.Cookies.Add(val2);
					base.TempData["loginOtherSystemData"] = loginViewModel;
					return RedirectToAction("Login", "Account", (object)new
					{
						fromOtherSystems = true
					});
				}
			}
		}
		return Redirect(FormsAuthentication.DefaultUrl);
	}

	public async Task<ActionResult> KaramadLoginCallback()
	{
		return Redirect(FormsAuthentication.DefaultUrl);
	}

	public async Task<ActionResult> KaramadLogout()
	{
		if (base.Request.IsAuthenticated)
		{
			AuthenticateResult authenticateResult = await base.HttpContext.GetOwinContext().Authentication.AuthenticateAsync("KaramadSSO");
			string text = ((authenticateResult != null && authenticateResult.Properties.Dictionary.ContainsKey("id_token")) ? authenticateResult.Properties.Dictionary["id_token"] : null);
			string text2 = OtherSystems.KaramadProvider.BaseUrl + "/protocol/openid-connect/logout?post_logout_redirect_uri=" + FormsAuthentication.DefaultUrl;
			if (text != null)
			{
				text2 = text2 + "&id_token_hint=" + text;
			}
			base.HttpContext.GetOwinContext().Authentication.SignOut("Cookies", "OpenIdConnect");
			return Redirect(text2);
		}
		return Redirect(FormsAuthentication.DefaultUrl);
	}
}
