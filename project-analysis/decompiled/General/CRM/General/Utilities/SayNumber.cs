using System;

namespace CRM.General.Utilities;

public static class SayNumber
{
	public static string GetNumber(double Number)
	{
		string text = null;
		try
		{
			if (Number <= 0.0)
			{
				return "صفر";
			}
			bool flag = false;
			int num = 0;
			int num2 = 0;
			double[] array = new double[7];
			text = Number.ToString().Trim();
			num2 = text.Length;
			if (num2 > 15 || text.Contains("E+"))
			{
				return "بسيار بزرگ";
			}
			for (num = 1; num <= 15 - num2; num++)
			{
				text = "0" + text;
			}
			for (num = 1; num <= Convert.ToInt32((double)(num2 / 3) + 0.99); num++)
			{
				if (num < 6)
				{
					array[5 - num + 1] = Convert.ToDouble(text.Substring(3 * (5 - num), 3));
				}
			}
			flag = false;
			text = "";
			for (num = 1; num <= 5; num++)
			{
				if (array[num] != 0.0)
				{
					switch (num)
					{
					case 1:
						text = text + Three(Convert.ToInt32(array[num])) + " تريليون";
						flag = true;
						break;
					case 2:
						text = text + (flag ? " و " : "") + Three(Convert.ToInt32(array[num])) + " ميليارد";
						flag = true;
						break;
					case 3:
						text = text + (flag ? " و " : "") + Three(Convert.ToInt32(array[num])) + " ميليون";
						flag = true;
						break;
					case 4:
						text = text + (flag ? " و " : "") + Three(Convert.ToInt32(array[num])) + " هزار";
						flag = true;
						break;
					case 5:
						text = text + (flag ? " و " : "") + Three(Convert.ToInt32(array[num]));
						break;
					}
				}
			}
		}
		catch
		{
			text = "خطا در محاسبه یا در عدد ورودی";
		}
		return text;
	}

	private static string Three(int Number)
	{
		string text = null;
		long num = 0L;
		long num2 = 0L;
		byte[] array = new byte[5];
		num2 = Number.ToString().Length;
		switch (Number)
		{
		case 0:
			return "";
		case 100:
			return "يكصد";
		default:
			if (num2 == 2)
			{
				array[1] = 0;
			}
			if (num2 == 1)
			{
				array[1] = 0;
				array[2] = 0;
			}
			for (num = 1L; num <= num2; num++)
			{
				array[3 - num + 1] = Convert.ToByte(Number.ToString().Trim().Substring(Convert.ToInt32(num2 - num), 1));
			}
			switch (array[1])
			{
			case 1:
				text = "يكصد";
				break;
			case 2:
				text = "دويست";
				break;
			case 3:
				text = "سيصد";
				break;
			case 4:
				text = "چهارصد";
				break;
			case 5:
				text = "پانصد";
				break;
			case 6:
				text = "ششصد";
				break;
			case 7:
				text = "هفتصد";
				break;
			case 8:
				text = "هشتصد";
				break;
			case 9:
				text = "نهصد";
				break;
			}
			switch (array[2])
			{
			case 1:
				switch (array[3])
				{
				case 0:
					text += " و ده";
					break;
				case 1:
					text += " و يازده";
					break;
				case 2:
					text += " و دوازده";
					break;
				case 3:
					text += " و سيزده";
					break;
				case 4:
					text += " و چهارده";
					break;
				case 5:
					text += " و پانزده";
					break;
				case 6:
					text += " و شانزده";
					break;
				case 7:
					text += " و هفده";
					break;
				case 8:
					text += " و هجده";
					break;
				case 9:
					text += " و نوزده";
					break;
				}
				break;
			case 2:
				text += " و بيست";
				break;
			case 3:
				text += " و سي";
				break;
			case 4:
				text += " و چهل";
				break;
			case 5:
				text += " و پنجاه";
				break;
			case 6:
				text += " و شصت";
				break;
			case 7:
				text += " و هفتاد";
				break;
			case 8:
				text += " و هشتاد";
				break;
			case 9:
				text += " و نود";
				break;
			}
			if (array[2] != 1)
			{
				switch (array[3])
				{
				case 1:
					text += " و يك";
					break;
				case 2:
					text += " و دو";
					break;
				case 3:
					text += " و سه";
					break;
				case 4:
					text += " و چهار";
					break;
				case 5:
					text += " و پنج";
					break;
				case 6:
					text += " و شش";
					break;
				case 7:
					text += " و هفت";
					break;
				case 8:
					text += " و هشت";
					break;
				case 9:
					text += " و نه";
					break;
				}
			}
			return (num2 < 3) ? text.Substring(2) : text;
		}
	}

	public static string GetEnglishNumberToWords(int number)
	{
		if (number == 0)
		{
			return "zero";
		}
		if (number < 0)
		{
			return "minus " + GetEnglishNumberToWords(System.Math.Abs(number));
		}
		string text = "";
		if (number / 1000000 > 0)
		{
			text = text + GetEnglishNumberToWords(number / 1000000) + " million ";
			number %= 1000000;
		}
		if (number / 1000 > 0)
		{
			text = text + GetEnglishNumberToWords(number / 1000) + " thousand ";
			number %= 1000;
		}
		if (number / 100 > 0)
		{
			text = text + GetEnglishNumberToWords(number / 100) + " hundred ";
			number %= 100;
		}
		if (number > 0)
		{
			if (text != "")
			{
				text += "and ";
			}
			string[] array = new string[20]
			{
				"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
				"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
			};
			string[] array2 = new string[10] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
			if (number < 20)
			{
				text += array[number];
			}
			else
			{
				text += array2[number / 10];
				if (number % 10 > 0)
				{
					text = text + "-" + array[number % 10];
				}
			}
		}
		return text;
	}

	public static string GetNumberInEnglish(double Number)
	{
		string text = null;
		try
		{
			if (Number <= 0.0)
			{
				return "zero";
			}
			bool flag = false;
			int num = 0;
			int num2 = 0;
			double[] array = new double[7];
			text = Number.ToString().Trim();
			num2 = text.Length;
			if (num2 > 15 || text.Contains("E+"))
			{
				return "very much";
			}
			for (num = 1; num <= 15 - num2; num++)
			{
				text = "0" + text;
			}
			for (num = 1; num <= Convert.ToInt32((double)(num2 / 3) + 0.99); num++)
			{
				if (num < 6)
				{
					array[5 - num + 1] = Convert.ToDouble(text.Substring(3 * (5 - num), 3));
				}
			}
			flag = false;
			text = "";
			for (num = 1; num <= 5; num++)
			{
				if (array[num] != 0.0)
				{
					switch (num)
					{
					case 1:
						text = text + ThreeEnglish(Convert.ToInt32(array[num])) + " trillion";
						flag = true;
						break;
					case 2:
						text = text + (flag ? " " : "") + ThreeEnglish(Convert.ToInt32(array[num])) + " billion";
						flag = true;
						break;
					case 3:
						text = text + (flag ? " " : "") + ThreeEnglish(Convert.ToInt32(array[num])) + " million";
						flag = true;
						break;
					case 4:
						text = text + (flag ? " " : "") + ThreeEnglish(Convert.ToInt32(array[num])) + " thousand";
						flag = true;
						break;
					case 5:
						text = text + (flag ? " " : "") + ThreeEnglish(Convert.ToInt32(array[num]));
						break;
					}
				}
			}
		}
		catch
		{
			text = "Error in calculation or in input number";
		}
		return text;
	}

	private static string ThreeEnglish(int Number)
	{
		string text = null;
		long num = 0L;
		long num2 = 0L;
		byte[] array = new byte[5];
		num2 = Number.ToString().Length;
		switch (Number)
		{
		case 0:
			return "";
		case 100:
			return "one hundred";
		default:
			if (num2 == 2)
			{
				array[1] = 0;
			}
			if (num2 == 1)
			{
				array[1] = 0;
				array[2] = 0;
			}
			for (num = 1L; num <= num2; num++)
			{
				array[3 - num + 1] = Convert.ToByte(Number.ToString().Trim().Substring(Convert.ToInt32(num2 - num), 1));
			}
			switch (array[1])
			{
			case 1:
				text = "one hundred";
				break;
			case 2:
				text = "two hundred";
				break;
			case 3:
				text = "three hundred";
				break;
			case 4:
				text = "four hundred";
				break;
			case 5:
				text = "five hundred";
				break;
			case 6:
				text = "six hundred";
				break;
			case 7:
				text = "seven hundred";
				break;
			case 8:
				text = "eight hundred";
				break;
			case 9:
				text = "nine hundred";
				break;
			}
			switch (array[2])
			{
			case 1:
				switch (array[3])
				{
				case 0:
					text += " ten";
					break;
				case 1:
					text += " eleven";
					break;
				case 2:
					text += " twelve";
					break;
				case 3:
					text += " thirteen";
					break;
				case 4:
					text += " fourteen";
					break;
				case 5:
					text += " fifteen";
					break;
				case 6:
					text += " sixteen";
					break;
				case 7:
					text += " seventeen";
					break;
				case 8:
					text += " eighteen";
					break;
				case 9:
					text += " nineteen";
					break;
				}
				break;
			case 2:
				text += " twenty";
				break;
			case 3:
				text += " thirty";
				break;
			case 4:
				text += " forty";
				break;
			case 5:
				text += " fifty";
				break;
			case 6:
				text += " sixty";
				break;
			case 7:
				text += " seventy";
				break;
			case 8:
				text += " eighty";
				break;
			case 9:
				text += " ninety";
				break;
			}
			if (array[2] != 1)
			{
				switch (array[3])
				{
				case 1:
					text += " one";
					break;
				case 2:
					text += " two";
					break;
				case 3:
					text += " three";
					break;
				case 4:
					text += " four";
					break;
				case 5:
					text += " five";
					break;
				case 6:
					text += " six";
					break;
				case 7:
					text += " seven";
					break;
				case 8:
					text += " eight";
					break;
				case 9:
					text += " nine";
					break;
				}
			}
			return (num2 >= 3) ? text : ((num2 == 1) ? text.Substring(1) : text);
		}
	}

	public static string GetNumberInArabic(double Number)
	{
		string text = null;
		try
		{
			if (Number <= 0.0)
			{
				return "صفر";
			}
			bool flag = false;
			int num = 0;
			int num2 = 0;
			double[] array = new double[7];
			text = Number.ToString().Trim();
			num2 = text.Length;
			if (num2 > 15 || text.Contains("E+"))
			{
				return "كثيرا جدا";
			}
			for (num = 1; num <= 15 - num2; num++)
			{
				text = "0" + text;
			}
			for (num = 1; num <= Convert.ToInt32((double)(num2 / 3) + 0.99); num++)
			{
				if (num < 6)
				{
					array[5 - num + 1] = Convert.ToDouble(text.Substring(3 * (5 - num), 3));
				}
			}
			flag = false;
			text = "";
			for (num = 1; num <= 5; num++)
			{
				if (array[num] != 0.0)
				{
					switch (num)
					{
					case 1:
						text = text + ThreeArabic(Convert.ToInt32(array[num])) + " تريليون";
						flag = true;
						break;
					case 2:
						text = text + (flag ? " و " : "") + ThreeArabic(Convert.ToInt32(array[num])) + " مليار";
						flag = true;
						break;
					case 3:
						text = text + (flag ? " و " : "") + ThreeArabic(Convert.ToInt32(array[num])) + " مليون";
						flag = true;
						break;
					case 4:
						text = text + (flag ? " و " : "") + ThreeArabic(Convert.ToInt32(array[num])) + " ألف";
						flag = true;
						break;
					case 5:
						text = text + (flag ? " و " : "") + ThreeArabic(Convert.ToInt32(array[num]));
						break;
					}
				}
			}
		}
		catch
		{
			text = "خطأ في الحساب أو في رقم الإدخال";
		}
		return text;
	}

	private static string ThreeArabic(int Number)
	{
		string text = null;
		long num = 0L;
		long num2 = 0L;
		byte[] array = new byte[5];
		num2 = Number.ToString().Length;
		switch (Number)
		{
		case 0:
			return "";
		case 100:
			return "مائة";
		default:
			if (num2 == 2)
			{
				array[1] = 0;
			}
			if (num2 == 1)
			{
				array[1] = 0;
				array[2] = 0;
			}
			for (num = 1L; num <= num2; num++)
			{
				array[3 - num + 1] = Convert.ToByte(Number.ToString().Trim().Substring(Convert.ToInt32(num2 - num), 1));
			}
			switch (array[1])
			{
			case 1:
				text = "مائة";
				break;
			case 2:
				text = "مائتين";
				break;
			case 3:
				text = "ثلاث مئة";
				break;
			case 4:
				text = "أربعة مئة";
				break;
			case 5:
				text = "خمسمائة";
				break;
			case 6:
				text = "ستمائة";
				break;
			case 7:
				text = "سبعمائة";
				break;
			case 8:
				text = "ثمان مائة";
				break;
			case 9:
				text = "تسعمائة";
				break;
			}
			switch (array[2])
			{
			case 1:
				switch (array[3])
				{
				case 0:
					text += " و عشرة";
					break;
				case 1:
					text += " و أحد عشر";
					break;
				case 2:
					text += " و اثني عشر";
					break;
				case 3:
					text += " و ثلاثة عشر";
					break;
				case 4:
					text += " و أربعة عشرة";
					break;
				case 5:
					text += " و خمسة عشر";
					break;
				case 6:
					text += " و السادس عشر";
					break;
				case 7:
					text += " و سبعة عشر";
					break;
				case 8:
					text += " و الثامنة عشر";
					break;
				case 9:
					text += " و تسعة عشر";
					break;
				}
				break;
			case 2:
				text += " و عشرون";
				break;
			case 3:
				text += " و ثلاثون";
				break;
			case 4:
				text += " و أربعين";
				break;
			case 5:
				text += " و خمسون";
				break;
			case 6:
				text += " و ستون";
				break;
			case 7:
				text += " و سبعون";
				break;
			case 8:
				text += " و ثمانون";
				break;
			case 9:
				text += " و تسعون";
				break;
			}
			if (array[2] != 1)
			{
				switch (array[3])
				{
				case 1:
					text += " و واحد";
					break;
				case 2:
					text += " و اثنان";
					break;
				case 3:
					text += " و ثلاثة";
					break;
				case 4:
					text += " و أربعة";
					break;
				case 5:
					text += " و خمسة";
					break;
				case 6:
					text += " و ستة";
					break;
				case 7:
					text += " و سبعة";
					break;
				case 8:
					text += " و ثمانية";
					break;
				case 9:
					text += " و تسعة";
					break;
				}
			}
			return (num2 < 3) ? text.Substring(2) : text;
		}
	}
}
