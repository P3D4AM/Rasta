using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class BaseInfo
{
	public string ConvertMd5(string input)
	{
		byte[] bytes = Encoding.Default.GetBytes(input);
		return Enumerable.Aggregate<byte, string>((IEnumerable<byte>)new MD5CryptoServiceProvider().ComputeHash(bytes), "", (Func<string, byte, string>)((string current, byte b) => current + b.ToString("X2")));
	}

	public string En2FaNumber(string str)
	{
		string result = "";
		try
		{
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (str != null && lCID == 1065)
			{
				str = str.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲")
					.Replace("3", "۳")
					.Replace("4", "۴")
					.Replace("5", "۵")
					.Replace("6", "۶")
					.Replace("7", "۷")
					.Replace("8", "۸")
					.Replace("9", "۹");
			}
			result = str ?? "";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string Fa2EnNumber(string str)
	{
		string result = "";
		try
		{
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (str != null && lCID == 1065)
			{
				str = str.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2")
					.Replace("۳", "3")
					.Replace("۴", "4")
					.Replace("۵", "5")
					.Replace("۶", "6")
					.Replace("۷", "7")
					.Replace("۸", "8")
					.Replace("۹", "9");
			}
			result = str ?? "";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string RgbToDelphiColor(string rgbColor)
	{
		string result = null;
		if (!string.IsNullOrEmpty(rgbColor))
		{
			if (rgbColor.IndexOf('#') != -1)
			{
				rgbColor = rgbColor.Replace("#", "");
			}
			string text = "00";
			string text2 = "00";
			string text3 = "00";
			if (rgbColor.Length == 6)
			{
				text = rgbColor.Substring(0, 2);
				text2 = rgbColor.Substring(2, 2);
				text3 = rgbColor.Substring(4, 2);
			}
			else if (rgbColor.Length == 3)
			{
				text = rgbColor[0].ToString() + rgbColor[0];
				text2 = rgbColor[1].ToString() + rgbColor[1];
				text3 = rgbColor[2].ToString() + rgbColor[2];
			}
			result = "$00" + text3.ToString() + text2.ToString() + text.ToString();
		}
		return result;
	}

	public string DelphiCToRgbolor(string rgbColor)
	{
		string result = null;
		if (!string.IsNullOrEmpty(rgbColor))
		{
			string text = rgbColor.Substring(3, 2);
			string text2 = rgbColor.Substring(5, 2);
			string text3 = rgbColor.Substring(7, 2);
			result = "#" + text3 + text2 + text;
		}
		return result;
	}

	public void SetCulture(int currLangId)
	{
		try
		{
			CultureInfo cultureInfo = new CultureInfo(currLangId);
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public static byte[] HexToByteArray(string hex)
	{
		return Enumerable.ToArray<byte>(Enumerable.Select<int, byte>(Enumerable.Where<int>(Enumerable.Range(0, hex.Length), (Func<int, bool>)((int x) => x % 2 == 0)), (Func<int, byte>)((int x) => Convert.ToByte(hex.Substring(x, 2), 16))));
	}

	public static string ConverSHA256(string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrWhiteSpace(value))
		{
			using SHA256 sHA = SHA256.Create();
			Encoding uTF = Encoding.UTF8;
			byte[] array = sHA.ComputeHash(uTF.GetBytes(value));
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
		}
		return stringBuilder.ToString();
	}
}
