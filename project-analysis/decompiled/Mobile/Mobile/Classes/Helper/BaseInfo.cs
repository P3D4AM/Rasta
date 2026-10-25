using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Elmah;
using GSD.Globalization;

namespace Mobile.Classes.Helper;

public class BaseInfo
{
	public string ConvertMd5(string input)
	{
		byte[] bytes = Encoding.Default.GetBytes(input);
		return Enumerable.Aggregate<byte, string>((IEnumerable<byte>)new MD5CryptoServiceProvider().ComputeHash(bytes), "", (Func<string, byte, string>)((string current, byte b) => current + b.ToString("X2")));
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
}
