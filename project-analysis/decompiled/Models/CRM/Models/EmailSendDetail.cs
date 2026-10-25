using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(EmailSendDetailMetadata))]
public class EmailSendDetail
{
	public int EmailSendDetailId { get; set; }

	public int EmailSendHeaderId { get; set; }

	public string EmailAddress { get; set; }

	public int? EmailCmpId { get; set; }

	public int? EmailCmpPrsId { get; set; }

	public int? EmailCmpPrjId { get; set; }

	public string EmailCmpPrsName { get; set; }

	public string EmailCmpName { get; set; }

	public string EmailPrsJob { get; set; }

	public DateTime SendDateTime { get; set; }

	public string SendDatePersian { get; set; }

	public DateTime? SendedDateTime { get; set; }

	public string SendedDatePersian { get; set; }

	public int StatusId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public int? TryCount { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? EmailCId { get; set; }

	public string EmailBcc { get; set; }

	public string EmailCc { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual EmailSendHeader EmailSendHeader { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }
}
