using System.Text.RegularExpressions;

namespace CRM.General.Security;

public class RegularExpression
{
	public const string RegularExpressionForInteger = "^(0|(\\+)?[1-9]{1}[0-9]{0,8}|(\\+)?[1-3]{1}[0-9]{1,9}|(\\+)?[4]{1}([0-1]{1}[0-9]{8}|[2]{1}([0-8]{1}[0-9]{7}|[9]{1}([0-3]{1}[0-9]{6}|[4]{1}([0-8]{1}[0-9]{5}|[9]{1}([0-5]{1}[0-9]{4}|[6]{1}([0-6]{1}[0-9]{3}|[7]{1}([0-1]{1}[0-9]{2}|[2]{1}([0-8]{1}[0-9]{1}|[9]{1}[0-5]{1})))))))))$";

	public const string RegularExpressionForUsername = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

	public const string RegularExpressionForPassword = "^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*\\W)\\S{8,30}$";

	public const string RegularExpressionForFileName = "[a-zA-Z0-9_]{1,100}";

	public const string RegularExpressionForSalary = "\\d{0,9}";

	public const string RegularExpressionForNationalCode = "\\d{10}";

	public const string RegularExpressionForUrl = "(http(s)?:\\/\\/)?(([a-z]+[a-z0-9\\-]*[.])?([a-z0-9]+[a-z0-9\\-]*[.])+[a-z]{2,3}|localhost)(\\/[a-z0-9_-]+[a-z0-9_ -]*)*\\/?(\\\\?[a-z0-9_-]+=[a-z0-9 ',.-]*(&amp;[a-z0-9_-]+=[a-z0-9 ',.-]*)*)?(#[a-z0-9/_-]*)?$";

	public const string RegularExpressionForEmail = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

	public const string RegularExpressionForPhoneNumber = "^[0-9]{3,20}$";

	public const string RegularExpressionForPersianMobile = "09([0-9])\\d{8}";

	public const string RegularExpressionForNumberOnly = "^\\d+$";

	public const string RegularExpressionForFarsi = "^[پچجحخهعغفقثصضشسییبلاتنمکگوئدكذرزطظژؤآةيإأء\u064b\u064c\u064d\u064e\u064f\u0650\u0651\\s]+$";

	public const string RegularExpressionForEnglish = "^[A-Za-z\\d_-]+$";

	public const string RegularExpressionForImageFileUpload = "(.*?)\\.(jpg|JPG|jpeg|JPEG|png|PNG|gif|GIF|bmp|BMP)$";

	public const string RegularExpressionForTimeOnly = "^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$";

	public const string RegularExpressionForTimeWithSecondOnly = "^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$";

	public const string RegularExpressionForPersianDate = "(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$";

	public const string RegularExpressionForDate = "(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$";

	public const string RegularExpressionForIpV4Address = "^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";

	public const string RegularExpressionJustNumber = "^[0-9]*$";

	private string _RegEx_Value = "";

	public const string _RegStr_HH_mm = "^(2[0-3]|[01]?[0-9]):[0-5][0-9]$";

	public RegularExpression(string value = "")
	{
		_RegEx_Value = value;
	}

	public bool Validate_yyyy_MM_dd_WithSlash()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return new Regex("(\\d{4}\\/\\d{2}\\/\\d{2})").IsMatch(_RegEx_Value);
	}

	public bool Validate_HH_mm()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return new Regex("^(2[0-3]|[01]?[0-9]):[0-5][0-9]$").IsMatch(_RegEx_Value);
	}
}
