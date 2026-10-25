using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SmsUserSendCreditMetadata
{
	[Key]
	public int ID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CreditUserId")]
	public int CreditUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CreditImportDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CreditAmount")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal Amount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CreditDescription")]
	public string Description { get; set; }

	public int UserID { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
