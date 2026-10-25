using System;
using System.Text.RegularExpressions;
using System.Web;

namespace CRM.General.Security;

public class CSecurity : IDisposable
{
	private const string ClassName = "CSecurity";

	public void Dispose()
	{
	}

	public static string RemoveHtmlTags(string text)
	{
		if (!string.IsNullOrEmpty(text))
		{
			return Regex.Replace(text, "<(.|\\n)*?>", string.Empty);
		}
		return string.Empty;
	}

	public string MakePassWord(string pass)
	{
		return CodeDecode.computeSHA1Hasher(CodeDecode.computeMD5Hash(CodeDecode.computeSHA1Hasher(pass)));
	}

	public static string HtmlEncode(string str)
	{
		try
		{
			return HttpUtility.HtmlEncode(str);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static bool isValidEmail(string Password)
	{
		string text = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
		return ((Group)Regex.Match(Password, text, (RegexOptions)1)).Success;
	}

	public static bool isValidFarsiName(string Name)
	{
		string text = "^[پچجحخهعغفقثصضشسییبلاتنمکگوئدكذرزطظژؤآةيإأء\u064b\u064c\u064d\u064e\u064f\u0650\u0651\\s]+$";
		return ((Group)Regex.Match(Name, text, (RegexOptions)1)).Success;
	}

	public static bool isValidMobile(string Mobile)
	{
		string text = "09([1-9])\\d{8}";
		return ((Group)Regex.Match(Mobile, text, (RegexOptions)1)).Success;
	}

	public static bool isValidDate(string Date)
	{
		string text = "^^(1[34]\\d\\d)\\/(1[012]|0[1-9])\\/(0[1-9]$|[12]\\d$|3[01]$)";
		return ((Group)Regex.Match(Date, text, (RegexOptions)1)).Success;
	}

	public static bool isValidCodeMeli(string CodeMeli)
	{
		string text = "^[0-9]{10}$";
		return ((Group)Regex.Match(CodeMeli, text, (RegexOptions)1)).Success;
	}

	public static bool isValidMoney(string Money)
	{
		string text = "^\\$?[0-9]+(,[0-9]{3})*(\\.[0-9]{2})?$";
		return ((Group)Regex.Match(Money, text, (RegexOptions)1)).Success;
	}

	public static bool isValidTele(string Tele)
	{
		string text = "^[0-9]{4,20}$";
		return ((Group)Regex.Match(Tele, text, (RegexOptions)1)).Success;
	}

	public static bool isValidTeleCode(string TeleCode)
	{
		string text = "^[0-9]{3,5}$";
		return ((Group)Regex.Match(TeleCode, text, (RegexOptions)1)).Success;
	}
}
