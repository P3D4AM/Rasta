using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(EmailSendHeaderMetadata))]
public class EmailSendHeader
{
	public int EmailSendHeaderId { get; set; }

	public int UserId { get; set; }

	public string Subject { get; set; }

	public string Body { get; set; }

	public DateTime StartDateTime { get; set; }

	public string StartDatePersian { get; set; }

	public DateTime? EndDateTime { get; set; }

	public string EndDatePersian { get; set; }

	public int PriorityId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public int EmailUsersInfoId { get; set; }

	public int EmailSettingId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string OTP { get; set; }

	public int? CId { get; set; }

	public string BodyNoHtml { get; set; }

	public string ReceiveMessageId { get; set; }

	public string ReceiveUID { get; set; }

	public virtual ICollection<EmailSendAttachment> EmailSendAttachment { get; set; }

	public virtual ICollection<EmailSendDetail> EmailSendDetail { get; set; }

	public virtual EmailSetting EmailSetting { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual EmailUsersInfo EmailUsersInfo { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public EmailSendHeader()
	{
		EmailSendAttachment = (ICollection<EmailSendAttachment>)new HashSet<EmailSendAttachment>();
		EmailSendDetail = (ICollection<EmailSendDetail>)new HashSet<EmailSendDetail>();
	}
}
