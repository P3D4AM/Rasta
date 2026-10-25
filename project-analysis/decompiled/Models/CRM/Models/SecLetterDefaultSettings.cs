using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SecLetterDefaultSettingsMetadata))]
public class SecLetterDefaultSettings
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

	public int? LDEmailUsersInfoId { get; set; }

	public int? LDEmailUserDefaultSettingId { get; set; }

	public int? LDNumberCounterId { get; set; }

	public int? LDVerificationWorkFlowId { get; set; }

	public bool? CanVerifyInSameContext { get; set; }

	public bool? IsPublic { get; set; }

	public virtual EmailUserDefaultSetting EmailUserDefaultSetting { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual ICollection<SecLetterDefaultSettings_Lang> SecLetterDefaultSettings_Lang { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual SecLetterNumberCounter SecLetterNumberCounter { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public SecLetterDefaultSettings()
	{
		SecLetterDefaultSettings_Lang = (ICollection<SecLetterDefaultSettings_Lang>)new HashSet<SecLetterDefaultSettings_Lang>();
	}
}
