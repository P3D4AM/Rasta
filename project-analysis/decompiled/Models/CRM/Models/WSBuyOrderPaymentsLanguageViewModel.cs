using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSBuyOrderPaymentsLanguageViewModel
{
	[Key]
	public int BuyOrderPaymentId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "bordPayImportDate")]
	public string ImportDate { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "bordPayTypeId")]
	public int bordpayTypeId { get; set; }

	public int bordpayOrderId { get; set; }

	public int? bordpayDocId { get; set; }

	public int? bordpayDocTypeId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "bordPayAmount")]
	public decimal bordpayAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordPayDocNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordpayDocNumber { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "bordPayDocDate")]
	public string bordpayDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordPayDescription")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordpayDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordPayDocAmount")]
	public decimal? bordpayDocAmount { get; set; }

	public int? bordpayFirstRegisterUserId { get; set; }

	public string bordpayFirstRegisteDatePersian { get; set; }

	public DateTime? bordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? bordpayDocDateTime { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordpayDeActive")]
	public bool? bordpayDeActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordpayAccountNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordpayAccountNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordpayAmountTemp")]
	public decimal? bordpayAmountTemp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordpayDocDateTemp")]
	public string bordpayDocDateTemp { get; set; }

	public DateTime? bordpayDocDateTimeTemp { get; set; }

	public int? bordpayHeadingUpDay { get; set; }

	public decimal? bordpayHeadingUpAmount { get; set; }

	public bool? ModeVirify { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordpayIsVerified")]
	public bool? bordpayIsVerified { get; set; }

	public int? bordpayVerifierId { get; set; }

	public string bordpayVerifier { get; set; }

	public DateTime? bordpayVerifiedRegisterDate { get; set; }

	public string bordpayVerifiedRegisterDatePersian { get; set; }

	public string bordpayDescription_Lang { get; set; }
}
