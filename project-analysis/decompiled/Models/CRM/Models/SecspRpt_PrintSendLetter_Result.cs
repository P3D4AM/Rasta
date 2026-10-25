using System;

namespace CRM.Models;

public class SecspRpt_PrintSendLetter_Result
{
	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string RptUser { get; set; }

	public string LetterCompanyTitle { get; set; }

	public string LetterCompany { get; set; }

	public string LettercmpNickNameORCompanyTitle { get; set; }

	public string LettercmpNickNameORCompany { get; set; }

	public string LetterPerson { get; set; }

	public string LetterPersonJob { get; set; }

	public string LetterPersonDepartment { get; set; }

	public string LettercmpPersonNickNameORcmpPerson { get; set; }

	public string LetterProject { get; set; }

	public string prjTitle { get; set; }

	public string prjPostFix { get; set; }

	public string LetterVerifier { get; set; }

	public string LetterVerifierRequest { get; set; }

	public string FirstRegisterUser { get; set; }

	public string User { get; set; }

	public string LetterType { get; set; }

	public int LetterId { get; set; }

	public int LetterTypeId { get; set; }

	public string LetterDate { get; set; }

	public DateTime LetterDateTime { get; set; }

	public string LetterPreNumber { get; set; }

	public long LetterNumber { get; set; }

	public string LetterPreNumberII { get; set; }

	public long? LetterNumberII { get; set; }

	public string LetterAnnex { get; set; }

	public int? LetterCompanyId { get; set; }

	public string LettercmpNickName { get; set; }

	public int? LettercmpPersonId { get; set; }

	public string LettercmpPersonNickName { get; set; }

	public int? LettercmpProjectId { get; set; }

	public string LetterSubject { get; set; }

	public string LetterHeader { get; set; }

	public string LetterContext { get; set; }

	public string LetterFooter { get; set; }

	public string LetterSigningI { get; set; }

	public string LetterSigningII { get; set; }

	public string LetterSigningIII { get; set; }

	public string LetterSigningIV { get; set; }

	public int? LetterPrintFormatId { get; set; }

	public string LetterLastPrintDate { get; set; }

	public string LetterLastPrintTime { get; set; }

	public DateTime? LetterLastPrintDateTime { get; set; }

	public bool? LetterIsVerified { get; set; }

	public int? LetterVerifierId { get; set; }

	public int? LetterVerifierRequestId { get; set; }

	public DateTime? LetterVerifiedRegisterDate { get; set; }

	public string LetterVerifiedRegisterDatePersian { get; set; }

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

	public int? LanguageID { get; set; }

	public int? LetterCompanyNumber { get; set; }

	public int? LetterEmailUsersInfoId { get; set; }

	public string LetterEmailUsersInfo { get; set; }

	public int? LetterEmailUserDefaultSettingId { get; set; }

	public string LetterEmailUserDefaultSetting { get; set; }

	public int? LetterNumberCounterId { get; set; }

	public string LetterNumberCounter { get; set; }

	public string LetterContextRtf { get; set; }

	public int? LetterVerificationWorkFlowId { get; set; }

	public string LetterVerificationWorkFlow { get; set; }

	public int? LetterCId { get; set; }

	public string LetterCenterName { get; set; }

	public string LetterCenterCode { get; set; }
}
