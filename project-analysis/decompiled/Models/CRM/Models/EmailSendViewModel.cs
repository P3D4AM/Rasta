using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class EmailSendViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "EmailSubject")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Subject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailToEmails")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string ToEmails { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailBody")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[UIHint("RichText")]
	[AllowHtml]
	public string Body { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailFrom")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmptySelect")]
	public int From { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailIsNeedPdf")]
	public bool IsNeedPdf { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailPriority")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int Priority { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailSendingDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public DateTime SendingDate { get; set; }

	public int SettingId { get; set; }

	public string Type { get; set; }

	public string ReciveEmails { get; set; }

	public int? CompanyId { get; set; }

	public bool? HavePassword { get; set; }

	public string EmailReceiveAttachsPath { get; set; }

	public int? PersonId { get; set; }

	public int? ProjectId { get; set; }

	public string PositionName { get; set; }

	public int? EmailSystemPartId { get; set; }

	public long? EmailObjectId { get; set; }
}
