using System;
using System.Text;

namespace CRM.General.Text;

public static class Convert
{
	public static string Encode(string text)
	{
		return Encode(text, convertSpace: false);
	}

	public static string Encode(string text, bool convertSpace)
	{
		if (text == null)
		{
			return string.Empty;
		}
		text = text.Trim();
		if (text == string.Empty)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i <= text.Length - 1; i++)
		{
			string empty = string.Empty;
			string text2 = string.Empty;
			empty = text[i].ToString();
			if (i < text.Length - 1)
			{
				text2 = text[i + 1].ToString();
			}
			if (empty != null)
			{
				int length = empty.Length;
				if (length == 1)
				{
					switch (empty[0])
					{
					case '\u200c':
						empty = "&#8204;";
						break;
					case '\r':
						empty = "";
						break;
					case '\n':
						empty = "<br />";
						break;
					case '؟':
						empty = "&#1567;";
						break;
					case '،':
						empty = "&#1548;";
						break;
					case '؛':
						empty = "&#1563;";
						break;
					case ' ':
						if (convertSpace)
						{
							empty = "&nbsp;";
						}
						break;
					case '0':
					case '۰':
						empty = "&#1776;";
						break;
					case '1':
					case '۱':
						empty = "&#1777;";
						break;
					case '2':
					case '۲':
						empty = "&#1778;";
						break;
					case '3':
					case '۳':
						empty = "&#1779;";
						break;
					case '4':
					case '۴':
						empty = "&#1780;";
						break;
					case '5':
					case '۵':
						empty = "&#1781;";
						break;
					case '6':
					case '۶':
						empty = "&#1782;";
						break;
					case '7':
					case '۷':
						empty = "&#1783;";
						break;
					case '8':
					case '۸':
						empty = "&#1784;";
						break;
					case '9':
					case '۹':
						empty = "&#1785;";
						break;
					case 'آ':
						empty = "&#1570;";
						break;
					case 'ا':
						empty = "&#1575;";
						break;
					case 'ب':
						empty = "&#1576;";
						break;
					case 'پ':
						empty = "&#1662;";
						break;
					case 'ت':
						empty = "&#1578;";
						break;
					case 'ث':
						empty = "&#1579;";
						break;
					case 'ج':
						empty = "&#1580;";
						break;
					case 'چ':
						empty = "&#1670;";
						break;
					case 'ح':
						empty = "&#1581;";
						break;
					case 'خ':
						empty = "&#1582;";
						break;
					case 'د':
						empty = "&#1583;";
						break;
					case 'ذ':
						empty = "&#1584;";
						break;
					case 'ر':
						empty = "&#1585;";
						break;
					case 'ز':
						empty = "&#1586;";
						break;
					case 'ژ':
						empty = "&#1688;";
						break;
					case 'س':
						empty = "&#1587;";
						break;
					case 'ش':
						empty = "&#1588;";
						break;
					case 'ص':
						empty = "&#1589;";
						break;
					case 'ض':
						empty = "&#1590;";
						break;
					case 'ط':
						empty = "&#1591;";
						break;
					case 'ظ':
						empty = "&#1592;";
						break;
					case 'ع':
						empty = "&#1593;";
						break;
					case 'غ':
						empty = "&#1594;";
						break;
					case 'ف':
						empty = "&#1601;";
						break;
					case 'ق':
						empty = "&#1602;";
						break;
					case 'ك':
					case 'ک':
						empty = "&#1705;";
						break;
					case 'گ':
						empty = "&#1711;";
						break;
					case 'ل':
						empty = "&#1604;";
						break;
					case 'م':
						empty = "&#1605;";
						break;
					case 'ن':
						empty = "&#1606;";
						break;
					case 'و':
						empty = "&#1608;";
						break;
					case 'ه':
						empty = "&#1607;";
						break;
					case 'ي':
					case 'ی':
						empty = ((!string.IsNullOrEmpty(text2) && !(text2 == " ")) ? ((!"÷×`~1!2@3#4$5%6^7&8*9(0)-_=+،؛,[]<.>/؟\\{}|ـ«»:abcdefghijklmnopqrstuvwxyz۹۸۷۶۵۴۳۲۱۰\u200c".ToUpper().Contains(text2.ToUpper())) ? "&#1610;" : "&#1740;") : "&#1740;");
						break;
					case 'ء':
						empty = "&#1569;";
						break;
					case 'ئ':
						empty = "&#1574;";
						break;
					}
				}
			}
			stringBuilder.Append(empty);
		}
		return stringBuilder.ToString();
	}

	public static string Decode(string text)
	{
		if (text == null)
		{
			return string.Empty;
		}
		text = text.Trim();
		if (text == string.Empty)
		{
			return string.Empty;
		}
		text = text.Replace("&#8204;", "\u200c");
		text = text.Replace("&#1567;", "؟");
		text = text.Replace("&#1548;", "،");
		text = text.Replace("&#1563;", "؛");
		text = text.Replace("&nbsp;", " ");
		text = text.Replace("&#1776;", "0");
		text = text.Replace("&#1777;", "1");
		text = text.Replace("&#1778;", "2");
		text = text.Replace("&#1779;", "3");
		text = text.Replace("&#1780;", "4");
		text = text.Replace("&#1781;", "5");
		text = text.Replace("&#1782;", "6");
		text = text.Replace("&#1783;", "7");
		text = text.Replace("&#1784;", "8");
		text = text.Replace("&#1785;", "9");
		text = text.Replace("&#1570;", "آ");
		text = text.Replace("&#1575;", "ا");
		text = text.Replace("&#1576;", "ب");
		text = text.Replace("&#1662;", "پ");
		text = text.Replace("&#1578;", "ت");
		text = text.Replace("&#1579;", "ث");
		text = text.Replace("&#1580;", "ج");
		text = text.Replace("&#1670;", "چ");
		text = text.Replace("&#1581;", "ح");
		text = text.Replace("&#1582;", "خ");
		text = text.Replace("&#1583;", "د");
		text = text.Replace("&#1584;", "ذ");
		text = text.Replace("&#1585;", "ر");
		text = text.Replace("&#1586;", "ز");
		text = text.Replace("&#1688;", "ژ");
		text = text.Replace("&#1587;", "س");
		text = text.Replace("&#1588;", "ش");
		text = text.Replace("&#1589;", "ص");
		text = text.Replace("&#1590;", "ض");
		text = text.Replace("&#1591;", "ط");
		text = text.Replace("&#1592;", "ظ");
		text = text.Replace("&#1593;", "ع");
		text = text.Replace("&#1594;", "غ");
		text = text.Replace("&#1601;", "ف");
		text = text.Replace("&#1602;", "ق");
		text = text.Replace("&#1705;", "ک");
		text = text.Replace("&#1711;", "گ");
		text = text.Replace("&#1604;", "ل");
		text = text.Replace("&#1605;", "م");
		text = text.Replace("&#1606;", "ن");
		text = text.Replace("&#1608;", "و");
		text = text.Replace("&#1607;", "ه");
		text = text.Replace("&#1610;", "ي");
		text = text.Replace("&#1740;", "ي");
		text = text.Replace("&#1569;", "ء");
		text = text.Replace("&#1574;", "ئ");
		text = text.Replace("<br>", Environment.NewLine);
		text = text.Replace("<br/>", Environment.NewLine);
		text = text.Replace("<br />", Environment.NewLine);
		return text;
	}

	public static string DatabaseToShow(long number)
	{
		return DatabaseToShow(number.ToString());
	}

	public static string DatabaseToShow(string text)
	{
		if (text == null)
		{
			return string.Empty;
		}
		text = text.Trim();
		if (text == string.Empty)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		for (int i = 0; i <= text.Length - 1; i++)
		{
			int num = System.Convert.ToInt32(text[i]);
			string text2 = "";
			if (i < text.Length - 1)
			{
				text2 = text[i + 1].ToString();
			}
			switch (num)
			{
			case 48:
			case 49:
			case 50:
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
				stringBuilder.Append(System.Convert.ToChar(num - 48 + 1776));
				break;
			case 1711:
				stringBuilder.Append(System.Convert.ToChar(1705));
				break;
			case 1604:
				stringBuilder.Append(System.Convert.ToChar(1711));
				break;
			case 1605:
				stringBuilder.Append(System.Convert.ToChar(1604));
				break;
			case 1606:
				stringBuilder.Append(System.Convert.ToChar(1605));
				break;
			case 1607:
				stringBuilder.Append(System.Convert.ToChar(1606));
				break;
			case 1610:
				stringBuilder.Append(System.Convert.ToChar(1607));
				break;
			case 1705:
				if (string.IsNullOrEmpty(text2))
				{
					stringBuilder.Append(System.Convert.ToChar(1740));
				}
				else if ("÷×`~1!2@3#4$5%6^7&8*9(0)-_=+،؛,[]<.>/؟\\{}|ـ«»:abcdefghijklmnopqrstuvwxyz۹۸۷۶۵۴۳۲۱۰\u200c".ToUpper().Contains(text2.ToUpper()))
				{
					stringBuilder.Append(System.Convert.ToChar(1740));
				}
				else
				{
					stringBuilder.Append(System.Convert.ToChar(1610));
				}
				break;
			default:
				stringBuilder.Append(System.Convert.ToChar(num));
				break;
			}
		}
		return stringBuilder.ToString();
	}

	public static string ShowToDatabase(string text)
	{
		if (text == null)
		{
			return string.Empty;
		}
		text = text.Trim();
		if (text == string.Empty)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		for (int i = 0; i <= text.Length - 1; i++)
		{
			int num = System.Convert.ToInt32(text[i]);
			switch (num)
			{
			case 1776:
			case 1777:
			case 1778:
			case 1779:
			case 1780:
			case 1781:
			case 1782:
			case 1783:
			case 1784:
			case 1785:
				stringBuilder.Append(System.Convert.ToChar(num - 1776 + 48));
				break;
			case 1705:
				stringBuilder.Append(System.Convert.ToChar(1711));
				break;
			case 1711:
				stringBuilder.Append(System.Convert.ToChar(1604));
				break;
			case 1604:
				stringBuilder.Append(System.Convert.ToChar(1605));
				break;
			case 1605:
				stringBuilder.Append(System.Convert.ToChar(1606));
				break;
			case 1606:
				stringBuilder.Append(System.Convert.ToChar(1607));
				break;
			case 1607:
				stringBuilder.Append(System.Convert.ToChar(1610));
				break;
			case 1610:
			case 1740:
				stringBuilder.Append(System.Convert.ToChar(1705));
				break;
			default:
				stringBuilder.Append(System.Convert.ToChar(num));
				break;
			}
		}
		return stringBuilder.ToString();
	}

	public static string UnicodeToDigits(string number)
	{
		if (number == null)
		{
			return string.Empty;
		}
		number = number.Trim();
		if (number == string.Empty)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i <= number.Length - 1; i++)
		{
			char c = number[i];
			if (c >= '۰' && c <= 'ۺ')
			{
				stringBuilder.Append(System.Convert.ToChar(c - 1776 + 48));
			}
			else
			{
				stringBuilder.Append(c.ToString());
			}
		}
		return stringBuilder.ToString();
	}

	public static string DisplayNumber(long? number)
	{
		return "";
	}

	public static string DisplayFormattedNumber(long? number)
	{
		return "";
	}

	public static string DigitsToUnicode(long number)
	{
		return DigitsToUnicode(number.ToString());
	}

	public static string DigitsToUnicode(string number)
	{
		if (number == null)
		{
			return string.Empty;
		}
		number = number.Trim();
		if (number == string.Empty)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i <= number.Length - 1; i++)
		{
			char c = number[i];
			if (c >= '0' && c <= '9')
			{
				stringBuilder.Append(System.Convert.ToChar(1776 + c - 48));
			}
			else
			{
				stringBuilder.Append(c.ToString());
			}
		}
		return stringBuilder.ToString();
	}

	public static string NumberToWord(long number)
	{
		return NumberToWord(number.ToString());
	}

	public static string NumberToWord(string number)
	{
		if (number == null)
		{
			return string.Empty;
		}
		number = number.Replace(" ", string.Empty);
		if (number == string.Empty)
		{
			return string.Empty;
		}
		number = number.Replace(",", string.Empty);
		number = UnicodeToDigits(number);
		if (!String.IsJustLong(number))
		{
			return string.Empty;
		}
		if (number.Length > 18)
		{
			return string.Empty;
		}
		if (number == "0")
		{
			return "صفر";
		}
		string[,] array = new string[10, 5]
		{
			{ "يک", "يازده", "ده", "يکصد", null },
			{ "دو", "دوازده", "بيست", "دويست", null },
			{ "سه", "سيزده", "سی", "سيصد", null },
			{ "چهار", "چهارده", "چهل", "چهارصد", null },
			{ "پنج", "پانزده", "پنجاه", "پانصد", null },
			{ "شش", "شانزده", "شصت", "ششصد", null },
			{ "هفت", "هفده", "هفتاد", "هفتصد", null },
			{ "هشت", "هجده", "هشتاد", "هشتصد", null },
			{ "نه", "نوزده", "نود", "نهصد", null },
			{ "هزار", "ميليون", "ميليارد", "تريليون", "کاتريليون" }
		};
		string text = "";
		string text2 = number;
		string text3 = "";
		int num = 0;
		int num2 = 0;
		int num3 = text2.Length;
		while (num3 > 0)
		{
			text3 = ((num3 > 2) ? text2.Substring(num3 - 3, 3) : text2.Substring(0, num3));
			bool flag = false;
			string text4 = "";
			string value = text3;
			if (text3.Length == 3)
			{
				if (System.Convert.ToInt32(text3.Substring(0, 1)) > 0)
				{
					int num4 = System.Convert.ToInt32(text3.Substring(0, 1));
					text4 = array[num4 - 1, 3];
					flag = true;
				}
				text3 = text3.Substring(1, 2);
			}
			if (text3.Length == 2)
			{
				if (text3.Substring(0, 1) == "1" && text3.Substring(1, 1) != "0")
				{
					int num5 = System.Convert.ToInt32(text3.Substring(1, 1));
					text4 = ((!flag) ? (text4 + " " + array[num5 - 1, 1]) : (text4 + " و " + array[num5 - 1, 1]));
					flag = true;
					text3 = "";
				}
				else
				{
					if (text3.Substring(0, 1) != "0")
					{
						int num6 = System.Convert.ToInt32(text3.Substring(0, 1));
						text4 = ((!flag) ? (text4 + " " + array[num6 - 1, 2]) : (text4 + " و " + array[num6 - 1, 2]));
						flag = true;
					}
					text3 = text3.Substring(1, 1);
				}
			}
			if (text3.Length == 1 && text3 != "0")
			{
				int num7 = System.Convert.ToInt32(text3);
				text4 = ((!flag) ? (text4 + " " + array[num7 - 1, 0]) : (text4 + " و " + array[num7 - 1, 0]));
			}
			text4 = text4.Trim();
			if (text4.Length > 0 && num > 0)
			{
				text4 = text4 + " " + array[9, ((num - 1) * 10 + 1) / 10];
			}
			text = ((num <= 0 || num2 <= 0) ? (text4 + " " + text) : (text4 + " و " + text));
			num++;
			num3 -= 3;
			num2 = System.Convert.ToInt32(value);
		}
		text = text.Trim();
		if (text.Length == 0)
		{
			text = "صفر";
		}
		while (text.Contains("  "))
		{
			text = text.Replace("  ", " ");
		}
		return text;
	}

	public static string PdfToText1(string source)
	{
		if (string.IsNullOrEmpty(source))
		{
			return string.Empty;
		}
		source = source.Trim();
		if (source == string.Empty)
		{
			return string.Empty;
		}
		string text = string.Empty;
		string text2 = string.Empty;
		char? c = null;
		char? c2 = null;
		char c3 = '\0';
		for (int num = source.Length - 1; num >= 0; num--)
		{
			c2 = ((!string.IsNullOrEmpty(text)) ? new char?(System.Convert.ToChar(text.Substring(text.Length - 1))) : null);
			c3 = source[num];
			int num2 = System.Convert.ToInt32(c3);
			c = ((num != 0) ? new char?(source[num - 1]) : null);
			switch (num2)
			{
			case 2:
				text += "ک";
				break;
			case 3:
				text = ((((int?)c2).GetValueOrDefault() != 32) ? ((c2.HasValue && ((int?)c2).GetValueOrDefault() != 64 && c2 != '\u200c') ? (text + "ف") : (text + "ک")) : (text + "ف"));
				break;
			case 4:
				text = ((c2.HasValue && ((int?)c2).GetValueOrDefault() != 32 && ((int?)c2).GetValueOrDefault() != 64 && c2 != '\u200c') ? (text + "ظ") : (text + "ک"));
				break;
			case 5:
				text += "ف";
				break;
			case 6:
				text = ((((int?)c2).GetValueOrDefault() != 32) ? ((c2.HasValue && ((int?)c2).GetValueOrDefault() != 64 && c2 != '\u200c') ? (text + "ق") : (text + "ن")) : (text + "ن"));
				break;
			case 8:
				text += "ف";
				break;
			case 9:
				text += "ن";
				break;
			case 10:
				if (!c.HasValue || c != System.Convert.ToChar(13))
				{
					text += "ن";
					break;
				}
				text2 = ((!string.IsNullOrEmpty(text2)) ? (text + text2) : (text2 + text));
				text = string.Empty;
				break;
			case 11:
				text = ((((int?)c2).GetValueOrDefault() != 32) ? (text + "ف") : (text + "ق"));
				break;
			case 12:
				if (!c2.HasValue || ((int?)c2).GetValueOrDefault() == 32 || ((int?)c2).GetValueOrDefault() == 64 || c2 == '\u200c')
				{
					text += "ف";
					text += "\u200c";
				}
				else
				{
					text += "ق";
				}
				break;
			case 13:
				if (!c2.HasValue)
				{
					text += "ط";
				}
				else if (c2.Value != '\n')
				{
					text += "ط";
				}
				break;
			case 14:
				text += "ط";
				text += "\u200c";
				break;
			case 15:
				text += "ط";
				break;
			case 16:
				text += "ع";
				break;
			case 17:
				text += "ض";
				break;
			case 18:
				text += "ع";
				break;
			case 19:
				text += "ط";
				break;
			case 21:
				text += "غ";
				break;
			case 22:
				text += "ق";
				text += "\u200c";
				break;
			case 24:
				text += "ف";
				text += "\u200c";
				break;
			case 32:
				text += " ";
				break;
			case 44:
				text += "،";
				break;
			case 45:
				text += "-";
				break;
			case 47:
				text += ".";
				break;
			case 58:
				text += ":";
				break;
			case 59:
				text += ";";
				break;
			case 60:
				text += "»";
				break;
			case 62:
				text += "«";
				break;
			case 64:
				text2 = text + Environment.NewLine + text2;
				break;
			case 65:
				text += "ا";
				break;
			case 66:
				text += "ا";
				break;
			case 67:
				text += "آ";
				break;
			case 70:
				text += "أ";
				break;
			case 72:
				text += "ا";
				break;
			case 74:
				text += "ب";
				break;
			case 75:
				text += "ب";
				text += "\u200c";
				break;
			case 76:
				text += "ب";
				break;
			case 77:
				text += "ب";
				break;
			case 78:
				text += "پ";
				break;
			case 80:
				text += "پ";
				break;
			case 81:
				text += "پ";
				break;
			case 83:
				text += "ت";
				text += "\u200c";
				break;
			case 84:
				text += "ت";
				break;
			case 85:
				text += "ت";
				break;
			case 89:
				text += "ث";
				break;
			case 92:
				text += "ج";
				break;
			case 93:
				text += "ج";
				break;
			case 95:
				text += "چ";
				break;
			case 96:
				text += "چ";
				break;
			case 97:
				text += "چ";
				break;
			case 99:
				text += "ح";
				break;
			case 100:
				text += "ح";
				break;
			case 101:
				text += "ح";
				break;
			case 103:
				text += "خ";
				break;
			case 104:
				text += "خ";
				break;
			case 105:
				text += "خ";
				break;
			case 106:
				text += "د";
				break;
			case 107:
				text += "د";
				text += "\u200c";
				break;
			case 108:
				text += "ذ";
				text += "\u200c";
				break;
			case 109:
				text += "ذ";
				break;
			case 110:
				text += "ر";
				break;
			case 111:
				text += "ر";
				break;
			case 112:
				text += "ز";
				break;
			case 113:
				text += "ز";
				break;
			case 116:
				text += "س";
				text += "\u200c";
				break;
			case 117:
				text += "س";
				text += "\u200c";
				break;
			case 118:
				text += "س";
				break;
			case 119:
				text += "س";
				break;
			case 120:
				text += "ش";
				text += "\u200c";
				break;
			case 121:
				text += "ش";
				text += "\u200c";
				break;
			case 122:
				text += "ش";
				break;
			case 123:
				text += "ش";
				break;
			case 126:
				text += "ص";
				break;
			case 162:
				text += "گ";
				break;
			case 163:
				text += "گ";
				break;
			case 164:
				text += "ل";
				text += "\u200c";
				break;
			case 165:
				text += "ل";
				break;
			case 166:
				text += "ل";
				break;
			case 167:
				text += "ل";
				break;
			case 168:
				text += "م";
				break;
			case 169:
				text += "م";
				break;
			case 170:
				text += "م";
				break;
			case 171:
				text += "م";
				break;
			case 172:
				text += "ن";
				break;
			case 174:
				text += "ن";
				break;
			case 175:
				text += "ن";
				break;
			case 176:
				text += "و";
				break;
			case 177:
				text += "و";
				break;
			case 178:
				text += "ه";
				text += "\u200c";
				break;
			case 179:
				text += "ه";
				text += "\u200c";
				break;
			case 180:
				text += "ه";
				break;
			case 182:
				text += "ه";
				break;
			case 183:
				text += "ه";
				break;
			case 186:
				text += "ی";
				text += "\u200c";
				break;
			case 187:
				text += "ی";
				text += "\u200c";
				break;
			case 188:
				text += "ی";
				break;
			case 189:
				text += "ی";
				break;
			case 191:
				text += "لا";
				break;
			case 192:
				text += "لا";
				break;
			case 210:
				text += "ه";
				break;
			case 230:
				text += "ص";
				break;
			case 233:
				text += "ع";
				text += "\u200c";
				break;
			case 237:
				text += "ع";
				break;
			case 238:
				text += "ع";
				break;
			case 240:
				text += "ک";
				text += "\u200c";
				break;
			case 241:
				text += "ک";
				break;
			case 242:
				text += "گ";
				break;
			case 956:
				text += "ه";
				break;
			default:
				text = c3 switch
				{
					'X' => text + "ث", 
					'r' => text + "ژ", 
					'£' => text + "س", 
					'\u0017' => text + "ظ", 
					'¡' => text + "گ", 
					'«' => text + "م", 
					_ => text + c3, 
				};
				break;
			case 199:
			case 223:
				break;
			}
		}
		text2 = ((!string.IsNullOrEmpty(text2)) ? (text + text2) : (text2 + text));
		while (text2.IndexOf("  ") >= 0)
		{
			text2 = text2.Replace("  ", " ");
		}
		return text2;
	}

	public static string PdfToText2(string source)
	{
		if (string.IsNullOrEmpty(source))
		{
			return string.Empty;
		}
		string text = string.Empty;
		string empty = string.Empty;
		char c = '\0';
		for (int num = source.Length - 1; num >= 0; num--)
		{
			if (!string.IsNullOrEmpty(text))
			{
				System.Convert.ToChar(text.Substring(text.Length - 1));
			}
			c = source[num];
			int num2 = System.Convert.ToInt32(c);
			if (num != 0)
			{
				_ = source[num - 1];
			}
			text = num2 switch
			{
				1 => text + "ن", 
				2 => text + "ي", 
				3 => text + "د", 
				4 => text + "ب", 
				5 => text + " ", 
				6 => text + "و", 
				7 => text + "ي", 
				8 => text + "م", 
				9 => text + "د", 
				10 => text + "ر", 
				11 => text + "ح", 
				12 => text + "ی", 
				13 => text + "ا", 
				14 => text + "ج", 
				15 => text + "ه", 
				16 => text + "ا", 
				17 => text + "ز", 
				18 => text + "آ", 
				19 => text + "و", 
				20 => text + "ت", 
				21 => text + "،", 
				23 => text + "خ", 
				24 => text + "س", 
				25 => text + "م", 
				26 => text + "ب", 
				27 => text + "ل", 
				28 => text + "ک", 
				29 => text + "ه", 
				30 => text + "گ", 
				31 => text + "ن", 
				32 => text + " ", 
				33 => text + "ش", 
				34 => text + "ن", 
				35 => text + "ش", 
				36 => text + "ت", 
				37 => text + "ف", 
				38 => text + "گ", 
				39 => text + "ر", 
				41 => text + "ح", 
				42 => text + "ش", 
				43 => text + "م", 
				44 => text + "ه", 
				45 => text + "ف", 
				46 => text + ".", 
				47 => text + "ز", 
				48 => text + "ک", 
				49 => text + "ج", 
				52 => text + "چ", 
				54 => text + "خ", 
				60 => text + "ع", 
				66 => text + "ض", 
				67 => text + "ص", 
				72 => text + "غ", 
				73 => text + "ظ", 
				_ => text + c, 
			};
		}
		empty = ((!string.IsNullOrEmpty(empty)) ? (text + empty) : (empty + text));
		while (empty.IndexOf("  ") >= 0)
		{
			empty = empty.Replace("  ", " ");
		}
		return empty;
	}

	public static string PdfToText3(string source)
	{
		if (string.IsNullOrEmpty(source))
		{
			return string.Empty;
		}
		string text = string.Empty;
		string empty = string.Empty;
		char? c = null;
		char c2 = '\0';
		for (int num = source.Length - 1; num >= 0; num--)
		{
			c = ((!string.IsNullOrEmpty(text)) ? new char?(System.Convert.ToChar(text.Substring(text.Length - 1))) : null);
			c2 = source[num];
			int num2 = System.Convert.ToInt32(c2);
			if (num != 0)
			{
				_ = source[num - 1];
			}
			switch (num2)
			{
			case 1:
				text += "ت";
				break;
			case 2:
				text += "ي";
				break;
			case 3:
				text += "ر";
				break;
			case 4:
				text += "د";
				break;
			case 5:
				text += "م";
				break;
			case 6:
				text = ((c != '\u200c' && c != '،') ? (text + " ") : (text + "ب"));
				break;
			case 8:
				text += "ن";
				break;
			case 9:
				text += "ا";
				break;
			case 10:
				text += "د";
				break;
			case 11:
				text += "،";
				break;
			case 13:
				text += "ا";
				break;
			case 14:
				text += "س";
				break;
			case 17:
				text += "ه";
				break;
			case 18:
				text += "ر";
				break;
			case 19:
				text += "م";
				break;
			case 20:
				text += "ش";
				break;
			case 23:
				text += "ز";
				break;
			case 24:
				text += "ي";
				break;
			case 25:
				text += "پ";
				break;
			case 30:
				text += "ع";
				break;
			case 31:
				text += "ح";
				break;
			case 32:
				text += "ف";
				break;
			case 34:
				text += "ز";
				break;
			case 36:
				text += "ت";
				break;
			case 40:
				text += "ی";
				break;
			case 41:
				text += "ع";
				break;
			case 42:
				text += "ن";
				break;
			case 43:
				text += "و";
				break;
			case 44:
				text += "گ";
				break;
			case 46:
				text += "آ";
				break;
			case 50:
				text += "ن";
				break;
			case 52:
				text += "ه";
				text += "\u200c";
				break;
			case 53:
				text += "س";
				break;
			case 57:
				text += "ف";
				break;
			case 63:
				text += "ب";
				break;
			case 64:
				text += "و";
				break;
			case 68:
				text += "ش";
				text += "\u200c";
				break;
			case 69:
				text += "ه";
				break;
			case 71:
				text += "ع";
				break;
			case 73:
				text += "خ";
				break;
			case 74:
				text += "ی";
				text += "\u200c";
				break;
			case 79:
				text += "ک";
				break;
			case 83:
				text += "ظ";
				break;
			case 84:
				text += "ص";
				break;
			case 85:
				text += "س";
				break;
			case 86:
				text += "ل";
				break;
			case 88:
				text += "ج";
				break;
			case 91:
				text += "ه";
				break;
			case 92:
				text += "ذ";
				break;
			case 95:
				text += "ح";
				break;
			case 98:
				text += "ت";
				break;
			case 101:
				text += "ب";
				break;
			case 109:
				text += "ث";
				break;
			case 111:
				text += "چ";
				break;
			case 133:
				text += "ف";
				break;
			case 8216:
				text += "م";
				break;
			case 8217:
				text += "ت";
				break;
			default:
				text += c2;
				break;
			case 75:
				break;
			}
		}
		empty = ((!string.IsNullOrEmpty(empty)) ? (text + empty) : (empty + text));
		while (empty.IndexOf("  ") >= 0)
		{
			empty = empty.Replace("  ", " ");
		}
		return empty;
	}

	public static string FixPersianText(string source, bool convertDigits)
	{
		if (string.IsNullOrEmpty(source))
		{
			return string.Empty;
		}
		source = source.Trim();
		if (source == string.Empty)
		{
			return string.Empty;
		}
		while (source.Contains("  "))
		{
			source = source.Replace("  ", " ");
		}
		source = source.Replace("{ ", "{");
		source = source.Replace("( ", "(");
		source = source.Replace("[ ", "[");
		source = source.Replace(" }", "}");
		source = source.Replace(" )", ")");
		source = source.Replace(" ]", "]");
		source = source.Replace(" !", "!");
		source = source.Replace(" ?", "?");
		source = source.Replace(" ؟", "؟");
		source = source.Replace(" .", ".");
		source = source.Replace(" :", ":");
		source = source.Replace(" ;", ";");
		source = source.Replace(" ؛", "؛");
		source = source.Replace(" ,", ",");
		source = source.Replace(" ،", "،");
		string text = string.Empty;
		for (int i = 0; i <= source.Length - 1; i++)
		{
			char c = source[i];
			char? c2 = ((i != source.Length - 1) ? new char?(source[i + 1]) : null);
			switch (c)
			{
			case '(':
			case '[':
			case '{':
				text = ((i != 0 && !(text.Substring(text.Length - 1) == " ") && !(text.Substring(text.Length - 1) == "\n") && !(text.Substring(text.Length - 1) == "\r")) ? (text + " " + c) : (text + c));
				break;
			case 'ئ':
			case 'ي':
			case 'ی':
				switch (c2)
				{
				case null:
				case ' ':
				case ')':
				case '<':
				case '>':
				case ']':
				case '}':
				case '\u200c':
					text += "ی";
					break;
				case '!':
				case '"':
				case '#':
				case '$':
				case '%':
				case '&':
				case '\'':
				case '(':
				case '*':
				case '+':
				case ',':
				case '-':
				case '.':
				case '/':
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
				case ':':
				case '=':
				case '?':
				case '@':
				case '[':
				case '\\':
				case '^':
				case '_':
				case '`':
				case '{':
				case '|':
				case '~':
				case '،':
				case '؛':
				case '؟':
					text += "ی";
					break;
				default:
					text += "ي";
					break;
				}
				break;
			case 'ك':
			case 'ک':
				text += "ک";
				break;
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				text = ((!convertDigits) ? (text + c) : (text + DigitsToUnicode(c.ToString())));
				break;
			case '!':
			case ')':
			case ',':
			case '.':
			case ':':
			case ';':
			case '?':
			case ']':
			case '}':
			case '،':
			case '؛':
			case '؟':
				text = ((c2 != ' ' && c2 != '\n' && c2 != '\r') ? (text + c + " ") : (text + c));
				break;
			default:
				text += c;
				break;
			}
		}
		return text;
	}

	public static string ToPersianNumber(string str)
	{
		string text = str.Trim();
		char[] temp = new char[text.Length];
		int i = 0;
		Array.ForEach(text.ToCharArray(), delegate(char b)
		{
			if (char.IsDigit(b))
			{
				temp[i] = (char)(b + 1728);
				i++;
			}
			else
			{
				temp[i] = b;
				i++;
			}
		});
		return new string(temp);
	}
}
