using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace CRM.General.Security;

public class AntiXssModule : IHttpModule
{
	private static readonly Regex CleanAllTags = new Regex("<[^>]+>", (RegexOptions)8);

	private static readonly IList<string> IgnoreList = new List<string> { "__EVENTVALIDATION", "__LASTFOCUS", "__EVENTTARGET", "__EVENTARGUMENT", "__VIEWSTATE", "__SCROLLPOSITIONX", "__SCROLLPOSITIONY", "__VIEWSTATEENCRYPTED", "__ASYNCPOST", "pagedata" };

	private static readonly PropertyInfo ReadonlyProperty = typeof(NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

	public void Dispose()
	{
	}

	public void Init(HttpApplication context)
	{
		context.BeginRequest += cleanUpInput;
	}

	private static void cleanUpAndEncodeCookies(HttpCookieCollection cookiesCollection)
	{
		string[] allKeys = cookiesCollection.AllKeys;
		foreach (string text in allKeys)
		{
			HttpCookie val = cookiesCollection[text];
			if (val == null)
			{
				continue;
			}
			string[] allKeys2 = val.Values.AllKeys;
			foreach (string text2 in allKeys2)
			{
				string text3 = val.Values[text2];
				if (!string.IsNullOrEmpty(text3))
				{
					text3 = text3.Trim();
					string text4 = HttpUtility.HtmlEncode(CleanAllTags.Replace(text3, string.Empty));
					if (text3 != text4)
					{
						val.Values[text2] = text4;
					}
				}
			}
		}
	}

	private static void cleanUpAndEncodeFormFields(NameValueCollection formFieldsCollection)
	{
		ReadonlyProperty.SetValue(formFieldsCollection, false, null);
		string[] allKeys = formFieldsCollection.AllKeys;
		foreach (string text in allKeys)
		{
			string text2 = formFieldsCollection[text];
			if (string.IsNullOrEmpty(text2))
			{
				continue;
			}
			text2 = text2.Trim();
			if (!IgnoreList.Contains(text))
			{
				string text3 = text2.ToSafeHtml();
				if (text2 != text3)
				{
					formFieldsCollection[text] = text3;
				}
			}
		}
		ReadonlyProperty.SetValue(formFieldsCollection, true, null);
	}

	private static void cleanUpAndEncodeQueryStrings(NameValueCollection queryStringsCollection)
	{
		ReadonlyProperty.SetValue(queryStringsCollection, false, null);
		string[] allKeys = queryStringsCollection.AllKeys;
		foreach (string text in allKeys)
		{
			string text2 = queryStringsCollection[text];
			if (!string.IsNullOrEmpty(text2))
			{
				text2 = text2.Trim();
				string text3 = HttpUtility.HtmlEncode(CleanAllTags.Replace(text2, string.Empty));
				if (text2 != text3)
				{
					queryStringsCollection[text] = text3;
				}
			}
		}
		ReadonlyProperty.SetValue(queryStringsCollection, true, null);
	}

	private static void cleanUpInput(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		HttpRequest request = ((HttpApplication)sender).Request;
		cleanUpAndEncodeQueryStrings(request.QueryString);
		if (request.HttpMethod == "POST")
		{
			cleanUpAndEncodeFormFields(request.Form);
		}
		cleanUpAndEncodeCookies(request.Cookies);
	}
}
