using System;

namespace Mobile.Models;

public class InsertErrorLogViewModel
{
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

	public int CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int CompanyPersonId { get; set; }

	public string PersonName { get; set; }

	public DateTime RegisterDate { get; set; }

	public int LanguageId { get; set; }
}
