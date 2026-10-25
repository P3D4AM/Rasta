using System;

namespace CRM.Models;

public class TSPspSelectSetting_Result
{
	public int TspSettingId { get; set; }

	public string TspSettingTitle { get; set; }

	public string TspIdentify { get; set; }

	public string TspPrivateKey { get; set; }

	public string TspSbc { get; set; }

	public string TspScln { get; set; }

	public string TspScc { get; set; }

	public string TspCrn { get; set; }

	public string TspBsrn { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? TspTob { get; set; }

	public string TspCoName { get; set; }

	public string TspRegistrationNumber { get; set; }

	public string TspEconomicCode { get; set; }

	public string TspNationalCode { get; set; }

	public string TspTel { get; set; }

	public int? TspCityId { get; set; }

	public string TspAddress { get; set; }

	public string TspZipCode { get; set; }

	public int? TspSendDateType { get; set; }

	public bool? TspSendPay { get; set; }
}
