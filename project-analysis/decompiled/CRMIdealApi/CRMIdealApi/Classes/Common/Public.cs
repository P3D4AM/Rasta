using System;
using System.Web;
using Elmah;

namespace CRMIdealApi.Classes.Common;

public class Public
{
	public static string HexToColor(string value = null)
	{
		string result = value;
		try
		{
			if (!string.IsNullOrWhiteSpace(value) && value.Contains("#"))
			{
				if (value.IndexOf('#') != -1)
				{
					value = value.Replace("#", "");
				}
				string text = "00";
				string text2 = "00";
				string text3 = "00";
				if (value.Length == 6)
				{
					text = value.Substring(0, 2);
					text2 = value.Substring(2, 2);
					text3 = value.Substring(4, 2);
				}
				else if (value.Length == 3)
				{
					text = value[0].ToString() + value[0];
					text2 = value[1].ToString() + value[1];
					text3 = value[2].ToString() + value[2];
				}
				string text4 = "$00" + text3.ToString() + text2.ToString() + text.ToString();
				result = text4;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string TColorToHex(string value = null)
	{
		string result = value;
		try
		{
			if (!string.IsNullOrWhiteSpace(value) && value.Contains("$"))
			{
				if (value.Length == 7)
				{
					value += "00";
				}
				string text = value.Substring(3, 2);
				string text2 = value.Substring(5, 2);
				string text3 = value.Substring(7, 2);
				result = "#" + text3 + text2 + text;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string GetUrlWithoutEndSlash(string url)
	{
		if (!string.IsNullOrWhiteSpace(url) && url.EndsWith("/"))
		{
			url = url.Substring(0, url.Length - 1);
		}
		return url;
	}

	public static void InsExceptToElmah(string ex)
	{
		try
		{
			ErrorSignal.FromCurrentContext().Raise(new Exception(ex));
		}
		catch (Exception)
		{
		}
	}

	public static void InsExceptToElmah(Exception ex)
	{
		try
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		catch (Exception)
		{
		}
	}

	public static void InsExceptToElmah(Exception ex, HttpContext context)
	{
		try
		{
			ErrorSignal.FromContext(context).Raise(ex);
		}
		catch (Exception)
		{
		}
	}
}
