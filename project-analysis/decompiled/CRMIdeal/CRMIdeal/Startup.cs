using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CRMIdeal.Classes.Helper;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace CRMIdeal;

public class Startup
{
	private static readonly object _lock = new object();

	private static bool _signalRInitialized = false;

	public void Configuration(IAppBuilder app)
	{
		lock (_lock)
		{
			if (_signalRInitialized)
			{
				return;
			}
			app.MapSignalR();
			bool requireHttpsMetadata = true;
			app.SetDefaultSignInAsAuthenticationType("ASP.NET_SessionId");
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = "ASP.NET_SessionId"
			});
			if (OtherSystems.KaramadProvider.IsActive)
			{
				app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
				{
					AuthenticationType = "KaramadSSO",
					SignInAsAuthenticationType = "KaramadSSO",
					Authority = OtherSystems.KaramadProvider.BaseUrl,
					ClientId = OtherSystems.KaramadProvider.ClientId,
					ClientSecret = OtherSystems.KaramadProvider.ClientSecret,
					RedirectUri = OtherSystems.KaramadProvider.RedirectCallBack,
					PostLogoutRedirectUri = OtherSystems.KaramadProvider.RedirectLogout,
					ResponseType = "code",
					Scope = "openid profile",
					RedeemCode = true,
					UsePkce = true,
					SaveTokens = true,
					RequireHttpsMetadata = requireHttpsMetadata,
					UseTokenLifetime = false,
					TokenValidationParameters = new TokenValidationParameters
					{
						NameClaimType = "name",
						RoleClaimType = "crm_role"
					},
					Notifications = new OpenIdConnectAuthenticationNotifications
					{
						AuthenticationFailed = delegate(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
						{
							context.HandleResponse();
							context.Response.Redirect("/Home/ShowMessage?message=Karamad Error:\n\n\n " + Uri.EscapeDataString(context.Exception.Message) + "&type=error");
							return Task.FromResult(0);
						},
						SecurityTokenValidated = async delegate(SecurityTokenValidatedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> n)
						{
							n.AuthenticationTicket.Identity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
						}
					}
				});
			}
			_signalRInitialized = true;
		}
	}
}
