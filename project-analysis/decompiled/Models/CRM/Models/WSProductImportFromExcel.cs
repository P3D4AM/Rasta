using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductImportFromExcelMetadata))]
public class WSProductImportFromExcel
{
	public long Id { get; set; }

	public int UserId { get; set; }

	public bool? Selector { get; set; }

	public int? RelationId { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public int? PrdColorId { get; set; }

	public int? PrdUnitId { get; set; }

	public int? PrdMinQty { get; set; }

	public int? PrdMaxQty { get; set; }

	public int? PrdSleepDay { get; set; }

	public string PrdFirstSerial { get; set; }

	public string PrdSecondSerial { get; set; }

	public string PrdThirdSerial { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdSecondBarcode { get; set; }

	public string PrdThirdBarcode { get; set; }

	public string PrdDescription { get; set; }

	public string PrdBarCode { get; set; }

	public int? PrdBarCodeTypeId { get; set; }

	public string PrdAutoNumBarcode { get; set; }

	public int? PrdAutoNumBarCodeTypeId { get; set; }

	public string PrdAutoCharBarcode { get; set; }

	public int? prdAutoCharBarCodeTypeId { get; set; }

	public string PrdModel { get; set; }

	public bool? PrdInactiveInSale { get; set; }

	public bool? PrdInactiveInBuy { get; set; }

	public string PriceDocDate { get; set; }

	public string PriceDocNumber { get; set; }

	public decimal? Price { get; set; }

	public decimal? PriceCurrencyPrice { get; set; }

	public int? PriceCurrencyUnitId { get; set; }

	public decimal? PriceCooperationPrice { get; set; }

	public decimal? PricePercent { get; set; }

	public decimal? PriceDiscountPrecent { get; set; }

	public decimal? PriceDiscount { get; set; }

	public decimal? PriceOtherPrice { get; set; }

	public string PriceDescription { get; set; }

	public int? PriceProductPriceGroupId { get; set; }

	public string CostDocDate { get; set; }

	public string CostDocNumber { get; set; }

	public decimal? Cost { get; set; }

	public decimal? CostCurrencyCost { get; set; }

	public int? CostCurrencyUnitId { get; set; }

	public decimal? CostTransportCost { get; set; }

	public decimal? CostReleasingCost { get; set; }

	public decimal? CostSlagCost { get; set; }

	public decimal? CostOtherCost { get; set; }

	public string CostDescription { get; set; }

	public int? CostProductCostGroupId { get; set; }

	public int? IsDuplicate { get; set; }

	public int? FindedPrdId { get; set; }

	public int? InsertedPrdId { get; set; }

	public string InsertedPriceIds { get; set; }

	public string InsertedCostIds { get; set; }

	public string AppType { get; set; }

	public string DuplicatedIds { get; set; }

	public string UpdatedPrdIds { get; set; }

	public string UpdatedPriceIds { get; set; }

	public string UpdatedCostIds { get; set; }

	public string Message { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? PrdSHPIsActive { get; set; }

	public string PrdSHPTitle { get; set; }

	public string PrdSHPCode { get; set; }

	public string PrdSHPModel { get; set; }

	public string PrdSHPDescription { get; set; }

	public string PrdSHPDescriptionII { get; set; }

	public int? PrdSHPStockManageTypeId { get; set; }

	public double? PrdSHPStockManualyCount { get; set; }

	public bool? PrdSHPHiddenPriceInNoStock { get; set; }

	public bool? PrdSHPSelfSupplier { get; set; }

	public int? PrdSHPOtherSupplierId { get; set; }

	public bool? PrdCommissionDisable { get; set; }

	public double? PrdCommissionPercentRate { get; set; }

	public bool? PrdIsDefault { get; set; }

	public bool? PrdInActive { get; set; }

	public int? PrdKind { get; set; }

	public string PrdDefQuantity { get; set; }

	public bool? PrdJustDefQuantity { get; set; }

	public double? PrdMinQuantity { get; set; }

	public double? PrdMaxQuantity { get; set; }

	public string PrdSpecificaionFieldValues { get; set; }

	public int? PriceCId { get; set; }

	public int? CostCId { get; set; }

	public bool? PrdSHPQtyFromTracing { get; set; }

	public int? LinkAccSettingDBId { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public decimal? PriceTaxIndexPrice { get; set; }

	public bool? PrdQtyCanDecimal { get; set; }

	public int? PrdFirstGroupId { get; set; }

	public int? PrdSecondGroupId { get; set; }

	public int? PrdUnitIdI { get; set; }

	public double? PrdUnitIRate { get; set; }

	public bool? PrdUnitIRateCalcAuto { get; set; }

	public int? PrdUnitIdII { get; set; }

	public double? PrdUnitIIRate { get; set; }

	public bool? PrdUnitIIRateCalcAuto { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual WSProductColor WSProductColor { get; set; }

	public virtual WSProductCostGroup WSProductCostGroup { get; set; }

	public virtual WSProductPriceGroup WSProductPriceGroup { get; set; }

	public virtual WSProductUnits WSProductUnits { get; set; }

	public virtual WSProductFirstGroup WSProductFirstGroup { get; set; }

	public virtual WSProductSecondGroup WSProductSecondGroup { get; set; }

	public virtual WSProductUnits WSProductUnits1 { get; set; }

	public virtual WSProductUnits WSProductUnits2 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
