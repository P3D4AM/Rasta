using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSPreOrderPaymentsLanguageViewModel
{
	[Key]
	public int PreOrderPaymentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordPayImportDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int pordpayTypeId { get; set; }

	public int pordpayPreOrderId { get; set; }

	public int? pordpayDocId { get; set; }

	public int? pordpayDocTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayAmount")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal pordpayAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayDocNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordpayDocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayDocDate")]
	public string pordpayDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayDocAmount")]
	public decimal? pordpayDocAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayDescription")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordpayDescription { get; set; }

	public int? pordpayFirstRegisterUserId { get; set; }

	public string pordpayFirstRegisteDatePersian { get; set; }

	public DateTime? pordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? pordpayDocDateTime { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? pordpayCompanyMoneyBagId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayDeActive")]
	public bool? pordpayDeActive { get; set; }

	public bool? ModeVirify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayAmountTemp")]
	public decimal? pordpayAmountTemp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayIsVerified")]
	public bool? pordpayIsVerified { get; set; }

	public int? pordpayVerifierId { get; set; }

	public string pordpayVerifier { get; set; }

	public DateTime? pordpayVerifiedRegisterDate { get; set; }

	public string pordpayVerifiedRegisterDatePersian { get; set; }

	public string pordpayFileTypeJson { get; set; }

	public string pordpayFileTypeJsonByName { get; set; }

	public string PayFilesJsonByName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayAccountNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordpayAccountNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayDocDateTemp")]
	public string pordpayDocDateTemp { get; set; }

	public DateTime? pordpayDocDateTimeTemp { get; set; }

	public int? pordpayBankingBankID { get; set; }

	public int? pordpayBankingBranchID { get; set; }

	public int? pordpayBankingAccountID { get; set; }

	public int? pordpayCashId { get; set; }

	public int? pordpayGroupIdI { get; set; }

	public int? pordpayGroupIdII { get; set; }

	public string pordpayChqSayadNumber { get; set; }

	public string pordpayChqSerialNumber { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordpayDocDayTemp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayBankName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordpayBankName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayBranchName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordpayBranchName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "pordpayBranchCode")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string pordpayBranchCode { get; set; }

	public int? pordpayBankingBankID_I { get; set; }

	public string pordpayDescription_Lang { get; set; }

	public string pordpayBankName_Lang { get; set; }

	public string pordpayBranchName_Lang { get; set; }
}
