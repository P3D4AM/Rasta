using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsGSMReceivesMetadata))]
public class SmsGSMReceives
{
	public int Id { get; set; }

	public int? Folder { get; set; }

	public int? Location { get; set; }

	public string ReceiveNumber { get; set; }

	public string ReceiveText { get; set; }

	public DateTime ReceiveTime { get; set; }

	public string ConcatenatedInfo { get; set; }

	public int? Coding { get; set; }

	public int? Status { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }
}
