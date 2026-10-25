using System;

namespace Mobile.Models;

public class MobspSelectEmailSetting_Result
{
	public int EmailSettingId { get; set; }

	public bool? EmailBulkingIsActive { get; set; }

	public int? EmailBulkingDelayTime { get; set; }

	public string EmailBulkingDailyStarTime { get; set; }

	public string EmailBulkingDailyEndTime { get; set; }

	public string EmailsAttachFilePath { get; set; }

	public string EmailsAttachShareFilePath { get; set; }

	public string CmpPattern { get; set; }

	public string CmpPrsPattern { get; set; }

	public string CmpPrsJobPattern { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string EmailSU { get; set; }

	public string EmailSP { get; set; }

	public string EmailSenderEditorFilePath { get; set; }

	public string EmailsPDFBodyFilePath { get; set; }

	public string EmailsAttachShareFilePathFtp { get; set; }

	public string EmailsPDFBodyFilePathFtp { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
