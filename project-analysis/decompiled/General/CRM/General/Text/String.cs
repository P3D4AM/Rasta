using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CRM.General.Text;

public static class String
{
	public static bool Contains(string text, string value, bool ignoreCase)
	{
		if (ignoreCase)
		{
			string text2 = text.ToLower();
			string value2 = value.ToLower();
			return text2.Contains(value2);
		}
		return text.Contains(value);
	}

	public static bool IsJustInt(string text)
	{
		if (text == null)
		{
			return false;
		}
		if (text == string.Empty)
		{
			return false;
		}
		try
		{
			System.Convert.ToInt32(text);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool IsNullOrEmptyOrInt(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		if (IsJustInt(text))
		{
			return true;
		}
		return false;
	}

	public static bool IsJustLong(string text)
	{
		if (text == null)
		{
			return false;
		}
		if (text == string.Empty)
		{
			return false;
		}
		try
		{
			System.Convert.ToInt64(text);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool IsNullOrNullStringOrLong(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		if (IsJustLong(text))
		{
			return true;
		}
		return false;
	}

	public static string CleanString(string value = "", bool allTrue = false, bool removeHiddenChars = false, bool forJson = false, bool canTrim = false)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return "";
		}
		string text = "";
		if (allTrue || removeHiddenChars)
		{
			int[] array = new int[111]
			{
				8192, 8193, 8194, 8195, 8196, 8197, 8198, 8199, 8200, 8201,
				8202, 8203, 8204, 8205, 8206, 8207, 8208, 8209, 8210, 8211,
				8212, 8213, 8214, 8215, 8216, 8217, 8218, 8219, 8220, 8221,
				8222, 8223, 8224, 8225, 8226, 8227, 8228, 8229, 8230, 8231,
				8232, 8233, 8234, 8235, 8236, 8237, 8238, 8239, 8240, 8241,
				8242, 8243, 8244, 8245, 8246, 8247, 8248, 8249, 8250, 8251,
				8252, 8253, 8254, 8255, 8256, 8257, 8258, 8259, 8260, 8261,
				8262, 8263, 8264, 8265, 8266, 8267, 8268, 8269, 8270, 8271,
				8272, 8273, 8274, 8275, 8276, 8277, 8278, 8279, 8280, 8281,
				8282, 8283, 8284, 8285, 8286, 8287, 8288, 8289, 8290, 8291,
				8292, 8294, 8295, 8296, 8297, 8298, 8299, 8300, 8301, 8302,
				8303
			};
			for (int i = 0; i < value.Length; i++)
			{
				char value2 = value[i];
				text = ((Array.IndexOf(array, System.Convert.ToInt32(value2)) != -1) ? (text + " ") : (text + value2));
			}
		}
		if (allTrue || forJson)
		{
			text = text.Replace("'", "''");
		}
		if (allTrue || canTrim)
		{
			text = text.Trim();
		}
		return text;
	}

	public static string FilterString(string str, bool keepNumber = false, bool keepEnglishAlpha = false, bool keepPersianbAlpha = false, char[] special = null)
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(str))
		{
			result = Enumerable.Aggregate<char, StringBuilder>((IEnumerable<char>)str, new StringBuilder(), (Func<StringBuilder, char, StringBuilder>)((StringBuilder sb, char c) => ((!keepNumber || !char.IsDigit(c)) && (!keepEnglishAlpha || ((c < 'A' || c > 'Z') && (c < 'a' || c > 'z'))) && (!keepPersianbAlpha || char.GetUnicodeCategory(c) != UnicodeCategory.OtherLetter) && (special == null || !Enumerable.Contains<char>((IEnumerable<char>)special, c))) ? sb.Append(string.Empty) : sb.Append(c))).ToString();
		}
		return result;
	}
}
