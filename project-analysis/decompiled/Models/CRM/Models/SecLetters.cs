using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SecLettersMetadata))]
public class SecLetters
{
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

	public int? LetterEmailUsersInfoId { get; set; }

	public int? LetterEmailUserDefaultSettingId { get; set; }

	public int? LetterNumberCounterId { get; set; }

	public string LetterContextRtf { get; set; }

	public int? LetterVerificationWorkFlowId { get; set; }

	public string LetterEditAfterFixInfoJs { get; set; }

	public bool? LetterIsFixed { get; set; }

	public int? LetterDefaultSettingId { get; set; }

	public int? LetterCId { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual EmailUserDefaultSetting EmailUserDefaultSetting { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual ICollection<SecLetters_Lang> SecLetters_Lang { get; set; }

	public virtual SecLetterType SecLetterType { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual SecLetterNumberCounter SecLetterNumberCounter { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public SecLetters()
	{
		SecLetters_Lang = (ICollection<SecLetters_Lang>)new HashSet<SecLetters_Lang>();
	}
}
