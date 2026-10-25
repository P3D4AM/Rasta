using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(EmailSettingMetadata))]
public class EmailSetting
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

	public string AppType { get; set; }

	public string EmailsAttachShareFilePathFtp { get; set; }

	public string EmailsPDFBodyFilePathFtp { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<EmailSendHeader> EmailSendHeader { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting2 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public EmailSetting()
	{
		EmailSendHeader = (ICollection<EmailSendHeader>)new HashSet<EmailSendHeader>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting2 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
	}
}
