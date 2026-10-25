using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsGSMSendingTankMetadata))]
public class SmsGSMSendingTank
{
	public int ID { get; set; }

	public string Number { get; set; }

	public string Body { get; set; }

	public bool? Sended { get; set; }

	public long? RefId { get; set; }

	public string Info { get; set; }

	public int? SendDetailId { get; set; }

	public int? SendUserId { get; set; }

	public string RequestTime { get; set; }

	public string RequestDate { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }
}
