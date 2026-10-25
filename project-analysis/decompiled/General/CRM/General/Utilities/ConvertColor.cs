using System;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CRM.General.Utilities;

public class ConvertColor
{
	private static char[] hexDigits = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	public static string ColorToHexString(Color color)
	{
		try
		{
			byte[] array = new byte[3]
			{
				((Color)(ref color)).R,
				((Color)(ref color)).G,
				((Color)(ref color)).B
			};
			char[] array2 = new char[array.Length * 2];
			for (int i = 0; i < array.Length; i++)
			{
				int num = array[i];
				array2[i * 2] = hexDigits[num >> 4];
				array2[i * 2 + 1] = hexDigits[num & 0xF];
			}
			return new string(array2);
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static Color HexStringToColor(string hexColor)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		string text = ExtractHexDigits(hexColor);
		if (text.Length != 6)
		{
			return Color.Empty;
		}
		string s = text.Substring(0, 2);
		string s2 = text.Substring(2, 2);
		string s3 = text.Substring(4, 2);
		Color empty = Color.Empty;
		try
		{
			int num = int.Parse(s, NumberStyles.HexNumber);
			int num2 = int.Parse(s2, NumberStyles.HexNumber);
			int num3 = int.Parse(s3, NumberStyles.HexNumber);
			return Color.FromArgb(num, num2, num3);
		}
		catch
		{
			return Color.Empty;
		}
	}

	private static string ExtractHexDigits(string input)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		string text = "";
		try
		{
			Regex val = new Regex("[abcdefABCDEF\\d]+", (RegexOptions)8);
			for (int i = 0; i < input.Length; i++)
			{
				char c = input[i];
				if (val.IsMatch(c.ToString()))
				{
					text += c;
				}
			}
		}
		catch
		{
			text = "";
		}
		return text;
	}

	public static Color ColorNameStringToColor(string colorName)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			foreach (object value in Enum.GetValues(typeof(KnownColor)))
			{
				if (colorName.Trim().ToLower() == value.ToString().Trim().ToLower())
				{
					return Color.FromKnownColor((KnownColor)value);
				}
			}
		}
		catch
		{
		}
		return Color.Empty;
	}
}
