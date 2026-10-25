using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSBuyOrderMetadata
{
	[Key]
	public int BuyOrderID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "BuyOrderOprId")]
	public int? BuyOrderOprId { get; set; }

	public int? PreBuyOrderId { get; set; }

	public int? PreBuyOrderVerifierId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordTitle { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "bordNumber")]
	public long bordNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordOrderNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordOrderNumber { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "bordDate")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordOrderDate")]
	[RegularExpression("(?:1[234]\\d{2})\\/(?:0?[1-9]|1[0-2])\\/(?:0?[1-9]|[12][0-9]|3[01])$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordOrderDate { get; set; }

	public DateTime? bordOrderDateTime { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "bordCompanyId")]
	public int bordCompanyId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "bordCompanyPersonId")]
	public int? bordCompanyPersonId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "bordProjectId")]
	public int? bordProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordSubject")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordSubject { get; set; }

	public int? bordItemCount { get; set; }

	public decimal? bordItemsAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDiscount")]
	public decimal? bordDiscount { get; set; }

	public decimal? bordSumAmount { get; set; }

	public decimal? bordTax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordTaxIndex")]
	[Range(typeof(decimal), "0", "100", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotInRange")]
	public decimal? bordTaxIndex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCalculateTax")]
	public bool? bordCalculateTax { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public string bordTotalAmountStr { get; set; }

	public bool? bordIsVerified { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordStatusId")]
	public int? bordStatusId { get; set; }

	public bool? bordIsFixed { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordPrintFormatId")]
	public int? bordPrintFormatId { get; set; }

	public string bordImportDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? bordVerifierId { get; set; }

	public DateTime? bordVerifiedRegisterDate { get; set; }

	public string bordVerifiedRegisterDatePersian { get; set; }

	public int? bordFirstRegisterUserId { get; set; }

	public int? bordSettlementTypeId { get; set; }

	public string bordDay { get; set; }

	public string bordTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordTransportation")]
	public decimal? bordTransportation { get; set; }

	public int? bordReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordRound")]
	public decimal? bordRound { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDiscountPercent")]
	[Range(typeof(decimal), "0", "100", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotInRange")]
	public decimal? bordDiscountPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDiscountTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordDiscountTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordNote")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordNote { get; set; }

	public DateTime? bordDateTime { get; set; }

	public DateTime? bordImportDateTime { get; set; }

	public string bordcmpTitle { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
