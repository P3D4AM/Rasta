using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using CRM.General.PushNotif;
using CRM.General.Utilities;
using Elmah;
using GSD.Globalization;
using Mobile.App_Start;
using Mobile.Cache.Setting;
using Mobile.Models;
using Stimulsoft.Base;

namespace Mobile;

public class WebApiApplication : HttpApplication
{
	public static class App
	{
		public static string SiteRootUrl;

		public static string ConnecttionString;
	}

	static WebApiApplication()
	{
		StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkcgIvwL0jnpsDqRpWg5FI5kt2G7A0tYIcUygBh1sPs7uPvgjp0GgDowCB/F6myz180QOXN+hAWpeqWhPokj7sFSjITHge+0Hvjw4vKQPmlfDn/OWCMfhCPY4cZMTeUW6cW2VSK+480C7TeIrX/O/tLgGrgklP1P/7MdEkP/gQjQIwyRizsmj17wLkWfRzMal1duePiYgMsYr8GE9AdT2Mz6RPH+SCwPKHdjCq5PI/k4SrswBNYyd60U3YHOve2dNPfteBnaTnzwpyfuKQSyJrPuccoqDVxIUWSF8GCXtQa2nf7qqvv7A9L4L2LSU3JS31y3NU4ykT1r2gg8lkLmXQlauRyq3SR3zhTCvr1gsuM8a/85YPA2KCT4T2X14/Sj6Z3uo9x8lFQPOsW3fk1us4HDqN54uz7DOynURHiLJ5Twy7m2SzZhgg7QKO07CZgff70N6ID1D/h2G8pjVhsUO5qkWEkdr2kj8ygbUq5OZcMYTuQXkt1+sVOet7/cmQGdjsxperXlhn/96fbzPPn/q4Q";
		StiLicense.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\StimulSoft\\license.key");
	}

	protected void Application_BeginRequest(object sender, EventArgs e)
	{
		try
		{
			string text = HttpContext.Current.Request.Headers["Origin"];
			string text2 = HttpContext.Current.Request.Headers["Sec-Fetch-Mode"];
			if (text != null && text2 == "cors")
			{
				string pwaServerUrl = SysSeting.Get().PwaServerUrl;
				if (!string.IsNullOrEmpty(pwaServerUrl) && Enumerable.Contains<string>((IEnumerable<string>)pwaServerUrl.Split(new char[1] { ',' }), text))
				{
					HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", text);
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
		if (string.IsNullOrWhiteSpace(App.ConnecttionString))
		{
			Database.SetInitializer<CRMEntities>(null);
			CRMEntities cRMEntities = new CRMEntities();
			App.ConnecttionString = cRMEntities.Database.Connection.ConnectionString;
			cRMEntities.Dispose();
		}
	}

	protected void Application_Start()
	{
		AreaRegistration.RegisterAllAreas();
		GlobalConfiguration.Configure(WebApiConfig.Register);
		FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
		RouteConfig.RegisterRoutes(RouteTable.Routes);
		ViewEngines.Engines.Clear();
		ViewEngines.Engines.Add(new CSharpRazorViewEngine());
		if (string.IsNullOrWhiteSpace(App.ConnecttionString))
		{
			Database.SetInitializer<CRMEntities>(null);
			CRMEntities cRMEntities = new CRMEntities();
			App.ConnecttionString = cRMEntities.Database.Connection.ConnectionString;
			cRMEntities.Dispose();
		}
		SqlDependency.Start(App.ConnecttionString);
		new FirebaseCloudMessaging().SetupFirebaseApp();
	}

	protected void Application_AcquireRequestState(object sender, EventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		string text = "";
		text = ApplicationSettings.GetValue("BeginCultureName");
		HttpCookie val = new HttpCookie("CurrentLanguage");
		val.Value = text;
		val.Expires = DateTime.MaxValue;
		HttpContext.Current.Response.Cookies.Add(val);
		if (text.Trim() == "" && HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
		{
			text = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
		}
		CultureInfo cultureInfo = new CultureInfo(text);
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
	}

	protected void Application_End()
	{
		SqlDependency.Stop(App.ConnecttionString);
	}
}
