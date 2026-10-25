using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CRMIdeal.Classes.Common;

public static class CheckValidNationalCode
{
	public static bool IsValidNationalCode(this string nationalCode)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(nationalCode))
		{
			return false;
		}
		if (nationalCode.Length != 10)
		{
			return false;
		}
		if (!new Regex("\\d{10}").IsMatch(nationalCode))
		{
			return false;
		}
		if (Enumerable.Contains<string>((IEnumerable<string>)new string[10] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" }, nationalCode))
		{
			return false;
		}
		char[] array = nationalCode.ToCharArray();
		int num = Convert.ToInt32(array[0].ToString()) * 10;
		int num2 = Convert.ToInt32(array[1].ToString()) * 9;
		int num3 = Convert.ToInt32(array[2].ToString()) * 8;
		int num4 = Convert.ToInt32(array[3].ToString()) * 7;
		int num5 = Convert.ToInt32(array[4].ToString()) * 6;
		int num6 = Convert.ToInt32(array[5].ToString()) * 5;
		int num7 = Convert.ToInt32(array[6].ToString()) * 4;
		int num8 = Convert.ToInt32(array[7].ToString()) * 3;
		int num9 = Convert.ToInt32(array[8].ToString()) * 2;
		int num10 = Convert.ToInt32(array[9].ToString());
		int num11 = (num + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9) % 11;
		if (num11 >= 2 || num10 != num11)
		{
			if (num11 >= 2)
			{
				return 11 - num11 == num10;
			}
			return false;
		}
		return true;
	}
}
