using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSBuyOrderLanguageViewModel
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
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordOrderDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
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

	[Display(ResourceType = typeof(Labels), Name = "bordTax")]
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

	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordcmpTitle { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCurrencyUnitId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? bordCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFacilityCmpId")]
	public int? bordFacilityCmpId { get; set; }

	public string bordFacilityCmp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFacilityPrsId")]
	public int? bordFacilityPrsId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFacilityPrjId")]
	public int? bordFacilityPrjId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordReqCmpId")]
	public int? bordReqCmpId { get; set; }

	public string bordReqCmp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordReqPrsId")]
	public int? bordReqPrsId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordReqPrjId")]
	public int? bordReqPrjId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDeliveryTerm")]
	public string bordDeliveryTerm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDeliveryDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordDeliveryDatePersian { get; set; }

	public DateTime? bordDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDeliveryTime")]
	public string bordDeliveryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordTaxCleared")]
	public bool? bordTaxCleared { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordTaxClearedDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordTaxClearedDatePersian { get; set; }

	public DateTime? bordTaxClearedDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFacilityCost")]
	public decimal? bordFacilityCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFacilityCostPercent")]
	public decimal? bordFacilityCostPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordSupplierDeliveryDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordSupplierDeliveryDatePersian { get; set; }

	public DateTime? bordSupplierDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordSupplierDeliveryTime")]
	public string bordSupplierDeliveryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordForwarderName")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordForwarderName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFreightCost")]
	public decimal? bordFreightCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFreightCurrUnId")]
	public int? bordFreightCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFreightCurrencyRate")]
	public double? bordFreightCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFinalFreightCost")]
	public decimal? bordFinalFreightCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCustomsPart")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordCustomsPart { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCustomsFee")]
	public decimal? bordCustomsFee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCustomsCurrUnId")]
	public int? bordCustomsCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCustomsCurrencyRate")]
	public double? bordCustomsCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFinalCustomsFee")]
	public decimal? bordFinalCustomsFee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFinalDeliveryDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordFinalDeliveryDatePersian { get; set; }

	public DateTime? bordFinalDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFinalDeliveryTime")]
	public string bordFinalDeliveryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCommission")]
	public decimal? bordCommission { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCommissionCurrUnId")]
	public int? bordCommissionCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCommissionCurrencyRate")]
	public double? bordCommissionCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordFinalCommission")]
	public decimal? bordFinalCommission { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordNumRef")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordNumRef { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordDefaultSettingId")]
	public int? bordDefaultSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordVerificationWorkFlowId")]
	public int? bordVerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCurrencyUnitIdI")]
	public int? bordCurrencyUnitIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "bordCurrencyUnitIRate")]
	public double? bordCurrencyUnitIRate { get; set; }

	public string bordTitle_Lang { get; set; }

	public string bordSubject_Lang { get; set; }

	public string bordTotalAmountStr_Lang { get; set; }

	public string bordDiscountTitle_Lang { get; set; }

	public string bordNote_Lang { get; set; }

	public string bordcmpTitle_Lang { get; set; }

	public string bordDeliveryTerm_Lang { get; set; }

	public string bordForwarderName_Lang { get; set; }

	public string bordCustomsPart_Lang { get; set; }

	public int? bordSuppUserId { get; set; }
}
