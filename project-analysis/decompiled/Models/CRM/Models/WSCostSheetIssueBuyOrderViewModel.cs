using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSCostSheetIssueBuyOrderViewModel
{
	public int CostSheetId { get; set; }

	public string CostSheetItemIds { get; set; }

	public int? bordIWHId { get; set; }

	public string BuyOrderPayments { get; set; }

	public int BuyOrderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordOprId")]
	public int? BuyOrderOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordOrderNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordOrderNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordOrderDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordOrderDate { get; set; }

	public DateTime? bordOrderDateTime { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ctshBordCompanyId")]
	public int bordCompanyId { get; set; }

	public string bordCompanyName { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ctshBordCompanyPersonId")]
	public int? bordCompanyPersonId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ctshBordProjectId")]
	public int? bordProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordReferUserId")]
	public int? bordReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFacilityCmpId")]
	public int? bordFacilityCmpId { get; set; }

	public string bordFacilityCmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFacilityPrsId")]
	public int? bordFacilityPrsId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFacilityPrjId")]
	public int? bordFacilityPrjId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordReqCmpId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? bordReqCmpId { get; set; }

	public string bordReqCmpName { get; set; }

	public string bordReqCmpNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordReqPrsId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? bordReqPrsId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "ctshBordReqPrjId")]
	public int? bordReqPrjId { get; set; }

	public string bordReqPrj { get; set; }

	public string bordPrjInquiryNum { get; set; }

	public string bordPrjNumRef { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordDeliveryTerm")]
	public string bordDeliveryTerm { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordDeliveryDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordDeliveryDatePersian { get; set; }

	public string bordDeliveryTime { get; set; }

	public DateTime? bordDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordSupplierDeliveryDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordSupplierDeliveryDatePersian { get; set; }

	public string bordSupplierDeliveryTime { get; set; }

	public DateTime? bordSupplierDeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFinalDeliveryDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string bordFinalDeliveryDatePersian { get; set; }

	public string bordFinalDeliveryTime { get; set; }

	public DateTime? bordFinalDeliveryDate { get; set; }

	public decimal? bordTax { get; set; }

	public decimal? bordTaxIndex { get; set; }

	public bool? bordCalculateTax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordNote")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordNote { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFacilityCost")]
	public decimal? bordFacilityCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFacilityCostPercent")]
	[Range(typeof(decimal), "0", "100", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotInRange")]
	public decimal? bordFacilityCostPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordForwarderName")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordForwarderName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFreightCost")]
	public decimal? bordFreightCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFreightCurrUnId")]
	public int? bordFreightCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFreightCurrencyRate")]
	public double? bordFreightCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFinalFreightCost")]
	public decimal? bordFinalFreightCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordCustomsPart")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string bordCustomsPart { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordCustomsFee")]
	public decimal? bordCustomsFee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordCustomsCurrUnId")]
	public int? bordCustomsCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordCustomsCurrencyRate")]
	public double? bordCustomsCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFinalCustomsFee")]
	public decimal? bordFinalCustomsFee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordTotalFinalCost")]
	public decimal? bordTotalFinalCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordCommission")]
	public decimal? bordCommission { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordCommissionCurrUnId")]
	public int? bordCommissionCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordCommissionCurrencyRate")]
	public double? bordCommissionCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordFinalCommission")]
	public decimal? bordFinalCommission { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordPayImportDate")]
	public string bordpayImportDate { get; set; }

	public string bordpayImportDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordPayTypeId")]
	public int? bordpayTypeId { get; set; }

	public string bordpayType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ctshBordPayAmount")]
	public decimal? bordpayAmount { get; set; }

	public string bordDeliveryTerm_Lang { get; set; }

	public string bordNote_Lang { get; set; }

	public string bordForwarderName_Lang { get; set; }

	public string bordCustomsPart_Lang { get; set; }
}
