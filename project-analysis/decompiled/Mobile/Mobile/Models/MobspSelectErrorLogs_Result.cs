using System;

namespace Mobile.Models;

public class MobspSelectErrorLogs_Result
{
	public int MobErrorLogId { get; set; }

	public string ActivityName { get; set; }

	public string Cause { get; set; }

	public string Discription { get; set; }

	public int AndroidVersion { get; set; }

	public string ApplicationVersion { get; set; }

	public string ApiVersion { get; set; }

	public string InternetType { get; set; }

	public string DeviceResolution { get; set; }

	public int UserId { get; set; }

	public string UserName { get; set; }

	public int CompanyID { get; set; }

	public string CompanyName { get; set; }

	public int CompanyPersonID { get; set; }

	public string PersonName { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int LanguageID { get; set; }
}
