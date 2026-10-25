using System;

namespace CRM.Models;

public class CRMspSelectTelegSetting_Result
{
	public int TelegSettingId { get; set; }

	public string PhoneNumber { get; set; }

	public int? TelegramId { get; set; }

	public int AppApiId { get; set; }

	public string AppApiHash { get; set; }

	public string AppTitle { get; set; }

	public bool IsActive { get; set; }

	public byte[] ProfilePicture { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string ProxyJs { get; set; }
}
