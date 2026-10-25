using System;
using System.Text;
using CRM.General.Enums;

namespace CRM.General.Utilities;

public static class MyRandom
{
	public static string GetRandomString(int length)
	{
		return GetRandomString(length, TextCase.Normal);
	}

	public static string GetRandomString(int length, TextCase textCase)
	{
		string result = string.Empty;
		string newGuidWithoutDash = Guid.NewGuidWithoutDash;
		int length2 = newGuidWithoutDash.Length;
		StringBuilder stringBuilder = new StringBuilder(length);
		Random random = new Random(DateTime.Now.Millisecond);
		for (int i = 1; i <= length; i++)
		{
			int index = random.Next(0, length2);
			stringBuilder.Append(newGuidWithoutDash[index]);
		}
		switch (textCase)
		{
		case TextCase.Normal:
			result = stringBuilder.ToString();
			break;
		case TextCase.LowerCase:
			result = stringBuilder.ToString().ToLower();
			break;
		case TextCase.UpperCase:
			result = stringBuilder.ToString().ToUpper();
			break;
		}
		return result;
	}
}
