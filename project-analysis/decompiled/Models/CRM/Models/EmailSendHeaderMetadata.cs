using System;
using System.Collections.Generic;

namespace CRM.Models;

internal class EmailSendHeaderMetadata
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

	public virtual ICollection<EmailSendAttachment> EmailSendAttachment { get; set; }

	public virtual ICollection<EmailSendDetail> EmailSendDetail { get; set; }

	public string AppType { get; set; }
}
