using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderPaymentsLanguageViewModel
{
	[Key]
	public int OrderPaymentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayImportDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ordpayTypeId { get; set; }

	public int ordpayOrderId { get; set; }

	public int? ordpayDocId { get; set; }

	public int? ordpayDocTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayAmount")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal ordpayAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayDocNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayDocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayDocDate")]
	public string ordpayDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayDescription")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayDescription { get; set; }

	public int? ordpayFirstRegisterUserId { get; set; }

	public string ordpayFirstRegisteDatePersian { get; set; }

	public DateTime? ordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? ordpayDocDateTime { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayDocAmount")]
	public decimal? ordpayDocAmount { get; set; }

	public int? PreOrderPaymentId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayBankDocNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayBankDocNumber { get; set; }

	public int? ordpayCompanyMoneyBagId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayDeActive")]
	public bool? ordpayDeActive { get; set; }

	public bool? ModeVirify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayAmountTemp")]
	public decimal? ordpayAmountTemp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayIsVerified")]
	public bool? ordpayIsVerified { get; set; }

	public int? ordpayVerifierId { get; set; }

	public string ordpayVerifier { get; set; }

	public DateTime? ordpayVerifiedRegisterDate { get; set; }

	public string ordpayVerifiedRegisterDatePersian { get; set; }

	public string ordpayFileTypeJson { get; set; }

	public string ordpayFileTypeJsonByName { get; set; }

	public string PayFilesJsonByName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayCardNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayCardNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayAccountNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayAccountNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayBankDocDate")]
	public string ordpayBankDocDatePersian { get; set; }

	public DateTime? ordpayBankDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayBankDocAmount")]
	public decimal? ordpayBankDocAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayBankDocDesc")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayBankDocDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayBankDocDescI")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayBankDocDescI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayBankDocRegisterUser")]
	public int? ordpayBankDocRegisterUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayBankDocRegisterDate")]
	public string ordpayBankDocRegisterDatePersian { get; set; }

	public DateTime? ordpayBankDocRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayDocDateTemp")]
	public string ordpayDocDateTemp { get; set; }

	public DateTime? ordpayDocDateTimeTemp { get; set; }

	public int? ordpayHeadingUpDay { get; set; }

	public decimal? ordpayHeadingUpAmount { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? ordpayDocDayTemp { get; set; }

	public int? ordpayBankingBankID { get; set; }

	public int? ordpayBankingBranchID { get; set; }

	public int? ordpayBankingAccountID { get; set; }

	public int? ordpayCashId { get; set; }

	public int? ordpayGroupIdI { get; set; }

	public int? ordpayGroupIdII { get; set; }

	public string ordpayChqSayadNumber { get; set; }

	public string ordpayChqSerialNumber { get; set; }

	public string TspOrdPayIinn { get; set; }

	public string TspOrdPayAcn { get; set; }

	public string TspOrdPayTrmn { get; set; }

	public int? TspOrdPayPmt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayBankName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayBankName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayBranchName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayBranchName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordpayBranchCode")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayBranchCode { get; set; }

	public int? ordpayBankingBankID_I { get; set; }

	public string ordpayDescription_Lang { get; set; }

	public string ordpayBankDocDesc_Lang { get; set; }

	public string ordpayBankDocDescI_Lang { get; set; }

	public string ordpayBankName_Lang { get; set; }

	public string ordpayBranchName_Lang { get; set; }
}
