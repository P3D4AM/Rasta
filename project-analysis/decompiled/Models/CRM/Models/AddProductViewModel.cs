using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class AddProductViewModel
{
	[Key]
	public int ProductId { get; set; }

	public int DetailId { get; set; }

	public int MasterId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdQuantity")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public double Quantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdQuantityDesc")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string QuantityDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblPrdPriceVm")]
	public decimal? Price { get; set; }

	public decimal? DiscountPrecent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblPrdDiscount")]
	public decimal? Discount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblPrdRoundAndRoundPlus")]
	public decimal? Round { get; set; }

	public decimal? RoundPlus { get; set; }

	public decimal? TotalPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDescription")]
	[MaxLength(12000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(12000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdVmFCR")]
	public double? FCR { get; set; }

	public double? FCRI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCalculateTax")]
	public bool CalculateTax { get; set; }

	public decimal? TaxIndex { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTaxI")]
	public decimal? Tax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSelectedNotVisible")]
	public bool SelectedNotVisible { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSelectedNotInSum")]
	public bool SelectedNotInSum { get; set; }

	public int? PrdUnitId { get; set; }

	public int? CurrencyUnitId { get; set; }

	public int? WHId { get; set; }

	public string WHIdLinkAcc { get; set; }

	public string LinkAccWHIdStr { get; set; }

	public string MasterForm { get; set; }

	public string QuantityDesc_Lang { get; set; }

	public string Description_Lang { get; set; }

	public string ForwarderName_Lang { get; set; }

	public string CustomsPart_Lang { get; set; }

	public string DescriptionI_Lang { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdPricePartRate")]
	public double? PricePartRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdPricePartI")]
	public decimal? PricePartI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdPricePartII")]
	public decimal? PricePartII { get; set; }

	public int? PrdPriceGroupId { get; set; }

	public string Tracing { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdPriceSum")]
	public decimal? PriceSum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDiscountSum")]
	public decimal? DiscountSum { get; set; }

	public decimal? DiscountISum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTaxSum")]
	public decimal? TaxSum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTaxCleared")]
	public bool? TaxCleared { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTaxClearedDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string TaxClearedDatePersian { get; set; }

	public DateTime? TaxClearedDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdFacilityCost")]
	public decimal? FacilityCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdFacilityCostPercent")]
	public decimal? FacilityCostPercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdForwarderName")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ForwarderName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdFreightCost")]
	public decimal? FreightCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdFreightCurrUnId")]
	public int? FreightCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdFreightCurrencyRate")]
	public double? FreightCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdFinalFreightCost")]
	public decimal? FinalFreightCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCustomsPart")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CustomsPart { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCustomsFee")]
	public decimal? CustomsFee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCustomsCurrUnId")]
	public int? CustomsCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCustomsCurrencyRate")]
	public double? CustomsCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdFinalCustomsFee")]
	public decimal? FinalCustomsFee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCommission")]
	public decimal? Commission { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCommissionCurrUnId")]
	public int? CommissionCurrUnId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCommissionCurrencyRate")]
	public double? CommissionCurrencyRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdFinalCommission")]
	public decimal? FinalCommission { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDeliveryTermId")]
	public int? DeliveryTermId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDeliveryDate_I")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string DeliveryDatePersian { get; set; }

	public DateTime? DeliveryDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDeliveryTime_I")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string DeliveryTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDeliveryEndDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string DeliveryEndDatePersian { get; set; }

	public DateTime? DeliveryEndDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDeliveryEndTime")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string DeliveryEndTime { get; set; }

	public string DeliveryDay { get; set; }

	public string DeliveryEndDay { get; set; }

	public bool? AddLinkedPrd { get; set; }

	public int? HaveSerial { get; set; }

	public int? OrdIWhId { get; set; }

	public string LinkedPrdIds { get; set; }

	public decimal PrdUserDiscountPercent { get; set; }

	public List<SelectListItem> ErrorsList { get; set; }

	public string ProductName { get; set; }

	public int? prdKind { get; set; }

	public int OprType { get; set; }

	public string ordILinkAccWHIdStr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityExpireDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string ValidityExpireDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdValidityExpireTime")]
	public string ValidityExpireTime { get; set; }

	public DateTime? ValidityExpireDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdQuantityTotal")]
	public double? QuantityTotal { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdColorId")]
	public int? PrdColorId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdUnitIdI_I")]
	public int? PrdUnitIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdUnitIRateResult")]
	public double? PrdUnitIRateResult { get; set; }

	public bool? PrdQtyNoFCR { get; set; }

	public bool? PrdMustFullTracingCode { get; set; }

	public bool? PrdSingleItem { get; set; }

	public bool? IsUnusable { get; set; }

	public string SysPart { get; set; }

	public int? CostId { get; set; }

	public decimal? Cost { get; set; }

	public bool? IsFix { get; set; }

	public bool? NotVisible { get; set; }

	public int? LinkAccItemId { get; set; }

	public string LinkAccItemIdStr { get; set; }

	public int? WHIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdValidityCountingNum")]
	public int? PrdValidityCountingNum { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdValidityCountingMin")]
	public int? PrdValidityCountingMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdNickname")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdNickname { get; set; }

	public string PrdNickname_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspCfee")]
	public decimal? TspCfee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspCut")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspCut { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspExr")]
	public decimal? TspExr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspOdt")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOdt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspOdr")]
	public decimal? TspOdr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspOdam")]
	public decimal? TspOdam { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspOlt")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspOlt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspOlr")]
	public decimal? TspOlr { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspOlam")]
	public decimal? TspOlam { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspConsfee")]
	public decimal? TspConsfee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspSpro")]
	public decimal? TspSpro { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspBros")]
	public decimal? TspBros { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspCop")]
	public decimal? TspCop { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspVop")]
	public decimal? TspVop { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspNw")]
	public double? TspNw { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspSsrv")]
	public decimal? TspSsrv { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspSscv")]
	public decimal? TspSscv { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspPspd")]
	public decimal? TspPspd { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspCui")]
	public decimal? TspCui { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdTspBsrn")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspBsrn { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDescriptionI")]
	[MaxLength(12000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(12000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DescriptionI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdAutoBillRate")]
	public decimal? PrdAutoCalcRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdAutoBillInflationRate")]
	public decimal? PrdAutoCalcInflationRateInfo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDeliveryUserId")]
	public int? PrdDeliveryUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdDeActiveModuleInReg")]
	public bool? PrdDeActiveModuleInReg { get; set; }

	public bool? PrdUnitIRateCalcAuto { get; set; }

	public double? PrdUnitIRate { get; set; }

	public bool? PrdCanChangePrice { get; set; }

	public string BuyOrderItemIds { get; set; }

	public bool? IsUpdateBordItem { get; set; }

	public int? DiscountCodeId { get; set; }

	public string DiscountCode { get; set; }

	public int? DiscountCodeUserId { get; set; }

	public string DiscountCodeUser { get; set; }

	public DateTime? DiscountCodeRegisterDate { get; set; }

	public string DiscountCodeRegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdSaleCenterId")]
	public int? SaleCenterId { get; set; }

	public string SaleCenterName { get; set; }

	public int? ParentSaleCenterId { get; set; }

	public double? PrdSHPLinkAccStock { get; set; }

	public int? LinkedItemRowNum { get; set; }

	public int? LinkedParentItemRowNum { get; set; }

	public int? LinkedParentPrdRowNum { get; set; }

	public bool? PrdAutoCalcPrice { get; set; }

	public double? PrdPriceCurrencyRate { get; set; }

	public double? ItemPrdWeight { get; set; }

	public double? PrdWeight { get; set; }

	public int? LinkAccSettingDBId { get; set; }

	public string PrdCode { get; set; }

	public decimal? PrdCost { get; set; }

	public bool? PrdQtyCanDecimal { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdUnitIdII_I")]
	public int? PrdUnitIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "AddPrdUnitIIRateResult")]
	public double? PrdUnitIIRateResult { get; set; }

	public bool? PrdUnitIIRateCalcAuto { get; set; }

	public double? PrdUnitIIRate { get; set; }
}
