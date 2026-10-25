using System.Text.RegularExpressions;

namespace CRM.General.Security;

public static class PersianProofWriter
{
	public const char ArabicKeChar = 'ك';

	public const char ArabicYeChar = 'ي';

	public const char PersianKeChar = 'ک';

	public const char PersianYeChar = 'ی';

	public static string ApplyHalfSpaceRule(this string text)
	{
		return Regex.Replace(Regex.Replace(text, "\\s+(ن?می)\\s+", " $1\u200c"), "\\s+(تر(ی(ن)?)?|ها(ی)?)\\s+", "\u200c$1 ");
	}

	public static string ApplyModeratePersianRules(this string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		if (!text.ContainsFarsi())
		{
			return text;
		}
		return text.ApplyPersianYeKe().ApplyHalfSpaceRule().YeHeHalfSpace()
			.CleanupZwnj()
			.CleanupExtraMarks();
	}

	public static string ApplyPersianYeKe(this string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		return text.Replace('ي', 'ی').Replace('ك', 'ک').Trim();
	}

	public static string CleanupExtraMarks(this string text)
	{
		return Regex.Replace(Regex.Replace(text, "(!){2,}", "$1"), "(؟){2,}", "$1");
	}

	public static string CleanupZwnj(this string text)
	{
		return Regex.Replace(text, "\\s+\u200c|\u200c\\s+", " ");
	}

	public static bool ContainsFarsi(this string text)
	{
		return Regex.IsMatch(text, "[\\u0600-\\u06FF]");
	}

	public static string YeHeHalfSpace(this string text)
	{
		return Regex.Replace(text, "(\\S)(ه[\\s\u200c]+[یي])(\\s)", "$1ه\u200cی\u200c$3");
	}
}
