using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SelectSendedDetailViewModel
{
	[Key]
	public int? ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsDetailSendBody")]
	public string Body { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsRefID")]
	public long? RefID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsNumbers")]
	public string Number { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsDeliveryStatus")]
	public string DeliveryStatus { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsCompanyName")]
	public string CompanyName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsPersonName")]
	public string PersonName { get; set; }

	public long? SID { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? UserId { get; set; }

	public int? StatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsStatusChange")]
	public string StatusChange { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "smsSendDateTime")]
	public string SendDateTime { get; set; }

	public int? BodyCount { get; set; }

	public string BodyLangType { get; set; }

	public decimal? BodyCost { get; set; }
}
