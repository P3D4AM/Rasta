using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMIdeal.Classes.Common;

public static class FormatingNumber
{
	public static string FormatForPrice(this string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return value;
		}
		string text = value;
		decimal num = decimal.Parse(value);
		if (value.IndexOf(".", StringComparison.Ordinal) >= 0)
		{
			string[] array = value.Split(new char[1] { '.' });
			if (Enumerable.Any<string>((IEnumerable<string>)array))
			{
				text = ((!(decimal.Parse(array[1]) > 0m)) ? $"{num:###,###,###,###}" : ((array[1].Length == 1) ? $"{num:N1}" : ((array[1].Length != 2) ? $"{num:N3}" : $"{num:N2}")));
			}
		}
		else
		{
			text = $"{num:###,###,###,###}";
		}
		if (num.ToString() == "0" || num.ToString() == "0.0" || num.ToString() == "0.00" || num == 0m)
		{
			text = num.ToString();
		}
		if (!string.IsNullOrEmpty(text))
		{
			text = text.Replace('.', '/');
		}
		return text;
	}

	public static string FormatForNum(this string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return value;
		}
		string text = value;
		decimal.Parse(value);
		if (!string.IsNullOrEmpty(text))
		{
			text = text.Replace('.', '/');
		}
		return text;
	}
}
