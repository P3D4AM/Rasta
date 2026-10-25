using System;

namespace CRM.Models;

public class SecspSelectLetterDefaultSettingsByUser_Result
{
	public int LetterDefaultSettingId { get; set; }

	public string LDTitle { get; set; }

	public string LDAnnex { get; set; }

	public string LDcmpNickName { get; set; }

	public string LDcmpPersonNickName { get; set; }

	public string LDSubject { get; set; }

	public string LDHeader { get; set; }

	public string LDContext { get; set; }

	public string LDFooter { get; set; }

	public string LDSigningI { get; set; }

	public string LDSigningII { get; set; }

	public string LDSigningIII { get; set; }

	public string LDSigningIV { get; set; }

	public int? LDPrintFormatId { get; set; }

	public int? LDReferUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LDVerifierRequestId { get; set; }

	public int? LanguageID { get; set; }

	public string User { get; set; }

	public string FirstRegisterUser { get; set; }

	public string LDReferUser { get; set; }

	public int? LDEmailUsersInfoId { get; set; }

	public int? LDEmailUserDefaultSettingId { get; set; }

	public int? LDNumberCounterId { get; set; }
}
