using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using CRM.General.PushNotif;
using CRM.General.Utilities;
using CRM.Models;
using CRMIdeal.App_Start;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using Elmah;
using Stimulsoft.Base;

namespace CRMIdeal;

public class MvcApplication : HttpApplication
{
	static MvcApplication()
	{
		StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkcgIvwL0jnpsDqRpWg5FI5kt2G7A0tYIcUygBh1sPs7uPvgjp0GgDowCB/F6myz180QOXN+hAWpeqWhPokj7sFSjITHge+0Hvjw4vKQPmlfDn/OWCMfhCPY4cZMTeUW6cW2VSK+480C7TeIrX/O/tLgGrgklP1P/7MdEkP/gQjQIwyRizsmj17wLkWfRzMal1duePiYgMsYr8GE9AdT2Mz6RPH+SCwPKHdjCq5PI/k4SrswBNYyd60U3YHOve2dNPfteBnaTnzwpyfuKQSyJrPuccoqDVxIUWSF8GCXtQa2nf7qqvv7A9L4L2LSU3JS31y3NU4ykT1r2gg8lkLmXQlauRyq3SR3zhTCvr1gsuM8a/85YPA2KCT4T2X14/Sj6Z3uo9x8lFQPOsW3fk1us4HDqN54uz7DOynURHiLJ5Twy7m2SzZhgg7QKO07CZgff70N6ID1D/h2G8pjVhsUO5qkWEkdr2kj8ygbUq5OZcMYTuQXkt1+sVOet7/cmQGdjsxperXlhn/96fbzPPn/q4Q";
		StiLicense.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\StimulSoft\\license.key");
	}

	protected void Application_BeginRequest(object sender, EventArgs e)
	{
		try
		{
			Public.InsTextToElmah();
			string text = HttpContext.Current.Request.Headers["Origin"];
			string text2 = HttpContext.Current.Request.Headers["Sec-Fetch-Mode"];
			string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
			if (text != null && text2 == "cors" && !absoluteUri.Contains(text))
			{
				string pwaServerUrl = SysSeting.Get().PwaServerUrl;
				if (!string.IsNullOrEmpty(pwaServerUrl))
				{
					string[] array = pwaServerUrl.Split(new char[1] { ',' });
					string text3 = "";
					string text4 = "";
					if (text.EndsWith("/"))
					{
						text3 = text;
						text4 = text.TrimEnd(new char[1] { '/' });
					}
					else
					{
						text3 = text + "/";
						text4 = text;
					}
					if (Enumerable.Contains<string>((IEnumerable<string>)array, text3))
					{
						HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", text);
					}
					else if (Enumerable.Contains<string>((IEnumerable<string>)array, text4))
					{
						HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", text);
					}
					else
					{
						Public.InsTextToElmah("CrosOrigin Disable In Global Part");
					}
				}
			}
			if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
			{
				HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, GET");
				HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "content-type, Accept, extra, charset, token, imeiCode, appName");
				HttpContext.Current.Response.End();
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		if (string.IsNullOrWhiteSpace(App.SiteRootUrl))
		{
			App.SiteRootUrl = ((HttpApplication)this).Request.Url.GetLeftPart(UriPartial.Authority) + ((HttpApplication)this).Request.ApplicationPath;
		}
		if (string.IsNullOrWhiteSpace(App.ConnecttionString))
		{
			Database.SetInitializer<CRMEntities>(null);
			Database.SetInitializer<CRMSpEntities>(null);
			Database.SetInitializer<CRMSpIEntities>(null);
			Database.SetInitializer<CRMTabelEntities>(null);
			Database.SetInitializer<CRMLinkSpEntities>(null);
			Database.SetInitializer<CRMSpIIEntities>(null);
			Database.SetInitializer<CRMSpIIIEntities>(null);
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			App.ConnecttionString = cRMSpEntities.Database.Connection.ConnectionString;
			cRMSpEntities.Dispose();
		}
	}

	protected void Application_Start()
	{
		AreaRegistration.RegisterAllAreas();
		GlobalConfiguration.Configure(WebApiConfig.Register);
		FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
		RouteConfig.RegisterRoutes(RouteTable.Routes);
		BundleConfig.RegisterBundles(BundleTable.Bundles);
		AuthConfig.RegisterAuth();
		ViewEngines.Engines.Clear();
		ViewEngines.Engines.Add(new CSharpRazorViewEngine());
		ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
		if (string.IsNullOrWhiteSpace(App.ConnecttionString))
		{
			Database.SetInitializer<CRMEntities>(null);
			Database.SetInitializer<CRMSpEntities>(null);
			Database.SetInitializer<CRMSpIEntities>(null);
			Database.SetInitializer<CRMTabelEntities>(null);
			Database.SetInitializer<CRMLinkSpEntities>(null);
			Database.SetInitializer<CRMSpIIEntities>(null);
			Database.SetInitializer<CRMSpIIIEntities>(null);
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			App.ConnecttionString = cRMSpEntities.Database.Connection.ConnectionString;
			cRMSpEntities.Dispose();
		}
		SqlDependency.Start(App.ConnecttionString);
		ChatHub.StartNotificationDependencies();
		new FirebaseCloudMessaging().SetupFirebaseApp();
		AntiForgeryConfig.UniqueClaimTypeIdentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
	}

	protected void Application_AcquireRequestState(object sender, EventArgs e)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		if (HttpContext.Current.Session == null)
		{
			return;
		}
		CultureInfo cultureInfo = (CultureInfo)((HttpApplication)this).Session["Culture"];
		if (cultureInfo == null)
		{
			string text = "";
			if (HttpContext.Current.Request.Cookies["CurrentLanguage"] != null)
			{
				text = HttpContext.Current.Request.Cookies["CurrentLanguage"].Value;
			}
			else
			{
				text = ApplicationSettings.GetValue("BeginCultureName");
				HttpCookie val = new HttpCookie("CurrentLanguage");
				val.Value = text;
				val.Expires = DateTime.MaxValue;
				HttpContext.Current.Response.Cookies.Add(val);
			}
			if (text.Trim() == "" && HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
			{
				text = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
			}
			cultureInfo = new CultureInfo(text);
			((HttpApplication)this).Session["Culture"] = cultureInfo;
		}
		cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
		cultureInfo.NumberFormat.NumberGroupSeparator = ",";
		cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		if (Thread.CurrentThread.CurrentCulture.LCID == 1065)
		{
			PersianCulture persianCulture = new PersianCulture();
			persianCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
			persianCulture.DateTimeFormat.LongDatePattern = "dddd d MMMM yyyy";
			persianCulture.DateTimeFormat.AMDesignator = "صبح";
			persianCulture.DateTimeFormat.PMDesignator = "عصر";
			Thread.CurrentThread.CurrentCulture = persianCulture;
			Thread.CurrentThread.CurrentUICulture = persianCulture;
			persianCulture.NumberFormat.NumberDecimalSeparator = ".";
			persianCulture.NumberFormat.NumberGroupSeparator = ",";
			persianCulture.NumberFormat.CurrencyDecimalSeparator = ".";
		}
		else if (Thread.CurrentThread.CurrentCulture.LCID == 1025)
		{
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern = "dddd d MMMM yyyy";
		}
		else if (Thread.CurrentThread.CurrentCulture.LCID == 1031)
		{
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator = "/";
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.TimeSeparator = ":";
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern = "dddd d MMMM yyyy";
		}
		else if (Thread.CurrentThread.CurrentCulture.LCID == 1055)
		{
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator = "/";
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.TimeSeparator = ":";
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
			Thread.CurrentThread.CurrentCulture.DateTimeFormat.LongDatePattern = "dddd d MMMM yyyy";
		}
	}

	protected void Session_Start(object sender, EventArgs e)
	{
	}

	protected void Session_End(object sender, EventArgs e)
	{
	}

	protected void Application_End()
	{
		string value = ApplicationSettings.GetValue("AlwaysUp");
		if (!string.IsNullOrEmpty(value) && (value.Trim().ToLower() == "true" || value.Trim().ToLower() == "True"))
		{
			DoWebRequest(App.SiteRootUrl);
		}
		SqlDependency.Stop(App.ConnecttionString);
	}

	public string DoWebRequest(string url)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			WebRequest obj = WebRequest.Create(url);
			obj.Credentials = CredentialCache.DefaultCredentials;
			HttpWebResponse val = (HttpWebResponse)obj.GetResponse();
			Stream responseStream = ((WebResponse)val).GetResponseStream();
			if (responseStream != null)
			{
				StreamReader streamReader = new StreamReader(responseStream);
				result = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
			}
			((WebResponse)val).Close();
		}
		catch
		{
		}
		return result;
	}

	protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		HttpCookie val = ((HttpApplication)this).Request.Cookies[".ASPXAUTH"];
		if (val != null)
		{
			GenericPrincipal val2 = new GenericPrincipal((IIdentity)new FormsIdentity(FormsAuthentication.Decrypt(val.Value)), (string[])null);
			HttpContext.Current.User = (IPrincipal)val2;
			Thread.CurrentPrincipal = (IPrincipal?)val2;
		}
	}
}
