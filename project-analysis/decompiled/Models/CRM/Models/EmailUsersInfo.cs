using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(EmailUsersInfoMetadata))]
public class EmailUsersInfo
{
	public int EmailUsersInfoId { get; set; }

	public int euUserId { get; set; }

	public string euNikeName { get; set; }

	public string euNikeEmail { get; set; }

	public string euPOP3Server { get; set; }

	public string euSMTPServer { get; set; }

	public string euUserName { get; set; }

	public string euPassword { get; set; }

	public bool euIsActive { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? euAutoDeleteReceivedEmail { get; set; }

	public bool? euPOP3UseSsl { get; set; }

	public int? euPOP3Port { get; set; }

	public int? euReceiveServerType { get; set; }

	public string euIMAPServer { get; set; }

	public bool? euIMAPUseSsl { get; set; }

	public int? euIMAPPort { get; set; }

	public bool? euDeleteSrvrAfterDelDb { get; set; }

	public int? euDeleteFromSrvrAfterDay { get; set; }

	public bool? euSMTPUseDefCredentials { get; set; }

	public bool? euSMTPUseSsl { get; set; }

	public int? euSMTPPort { get; set; }

	public string euDefBodyPatternFormula { get; set; }

	public bool? euIsDefault { get; set; }

	public virtual ICollection<CrmSurveySendSetting> CrmSurveySendSetting { get; set; }

	public virtual ICollection<EmailReceive> EmailReceive { get; set; }

	public virtual ICollection<EmailReceiveFolders> EmailReceiveFolders { get; set; }

	public virtual ICollection<EmailSendHeader> EmailSendHeader { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting2 { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public EmailUsersInfo()
	{
		CrmSurveySendSetting = (ICollection<CrmSurveySendSetting>)new HashSet<CrmSurveySendSetting>();
		EmailReceive = (ICollection<EmailReceive>)new HashSet<EmailReceive>();
		EmailReceiveFolders = (ICollection<EmailReceiveFolders>)new HashSet<EmailReceiveFolders>();
		EmailSendHeader = (ICollection<EmailSendHeader>)new HashSet<EmailSendHeader>();
		SecLetterDefaultSettings = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting2 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmConversationStatus = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
