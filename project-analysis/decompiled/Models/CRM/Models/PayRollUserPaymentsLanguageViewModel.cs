using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PayRollUserPaymentsLanguageViewModel
{
	[Key]
	public int PayRollUserPaymentId { get; set; }

	public int CycleId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "PayRollUserPayType")]
	public int PayTypeId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "PayRollUserPayAmount")]
	public decimal Amount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollUserPayAccountNumber")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UserAccountNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollUserPayPaymentNumber")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PaymentNumber { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "PayRollUserPayDate")]
	public string PaymentDatePersian { get; set; }

	public DateTime? PaymentDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollUserPayDescription")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PayRollUserPayBankingAccountId")]
	public int? BankingAccountId { get; set; }

	public string PayRollCycleTitle { get; set; }

	public decimal? PayRollCycleNetSalary { get; set; }

	public decimal? PayRollCycleAllPayRemain { get; set; }

	public string Description_Lang { get; set; }
}
