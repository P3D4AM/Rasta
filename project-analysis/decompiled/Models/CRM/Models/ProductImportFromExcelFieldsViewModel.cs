using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class ProductImportFromExcelFieldsViewModel
{
	public long Id { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdCode")]
	public string PrdCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdName")]
	public string PrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdLatinName")]
	public string PrdLatinName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdType")]
	public string PrdType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdDesign")]
	public string PrdDesign { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSize")]
	public string PrdSize { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdColorId")]
	public int? PrdColorId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdUnitId")]
	public int? PrdUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdMinQty")]
	public int? PrdMinQty { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdMaxQty")]
	public int? PrdMaxQty { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSleepDay")]
	public int? PrdSleepDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdFirstSerial")]
	public string PrdFirstSerial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSecondSerial")]
	public string PrdSecondSerial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdThirdSerial")]
	public string PrdThirdSerial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdFirstBarcode")]
	public string PrdFirstBarcode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSecondBarcode")]
	public string PrdSecondBarcode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdThirdBarcode")]
	public string PrdThirdBarcode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdDescription")]
	public string PrdDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdBarCode")]
	public string PrdBarCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdBarCodeTypeId")]
	public int? PrdBarCodeTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdAutoNumBarcode")]
	public string PrdAutoNumBarcode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdAutoNumBarCodeTypeId")]
	public int? PrdAutoNumBarCodeTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdAutoCharBarcode")]
	public string PrdAutoCharBarcode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelprdAutoCharBarCodeTypeId")]
	public int? prdAutoCharBarCodeTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdModel")]
	public string PrdModel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdInactiveInSale")]
	public bool? PrdInactiveInSale { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdInactiveInBuy")]
	public bool? PrdInactiveInBuy { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceDocDate")]
	public string PriceDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceDocNumber")]
	public string PriceDocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrice")]
	public decimal? Price { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceCurrencyPrice")]
	public decimal? PriceCurrencyPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceCurrencyUnitId")]
	public int? PriceCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceCooperationPrice")]
	public decimal? PriceCooperationPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPricePercent")]
	public decimal? PricePercent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceDiscountPrecent")]
	public decimal? PriceDiscountPrecent { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceDiscount")]
	public decimal? PriceDiscount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceOtherPrice")]
	public decimal? PriceOtherPrice { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceDescription")]
	public string PriceDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPriceProductPriceGroupId")]
	public int? PriceProductPriceGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostDocDate")]
	public string CostDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostDocNumber")]
	public string CostDocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCost")]
	public decimal? Cost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostCurrencyCost")]
	public decimal? CostCurrencyCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostCurrencyUnitId")]
	public int? CostCurrencyUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostTransportCost")]
	public decimal? CostTransportCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostReleasingCost")]
	public decimal? CostReleasingCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostSlagCost")]
	public decimal? CostSlagCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostOtherCost")]
	public decimal? CostOtherCost { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostDescription")]
	public string CostDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelCostProductCostGroupId")]
	public int? CostProductCostGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPIsActive")]
	public bool? PrdSHPIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPTitle")]
	public string PrdSHPTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPCode")]
	public string PrdSHPCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPModel")]
	public string PrdSHPModel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPDescription")]
	public string PrdSHPDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPDescriptionII")]
	public string PrdSHPDescriptionII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPStockManageTypeId")]
	public int? PrdSHPStockManageTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPStockManualyCount")]
	public double? PrdSHPStockManualyCount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPHiddenPriceInNoStock")]
	public bool? PrdSHPHiddenPriceInNoStock { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPSelfSupplier")]
	public bool? PrdSHPSelfSupplier { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPOtherSupplierId")]
	public int? PrdSHPOtherSupplierId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdSHPQtyFromTracing")]
	public bool? PrdSHPQtyFromTracing { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdQtyCanDecimal")]
	public bool? PrdQtyCanDecimal { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdCommissionDisable")]
	public bool? PrdCommissionDisable { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdCommissionPercentRate")]
	public double? PrdCommissionPercentRate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdIsDefault")]
	public bool? PrdIsDefault { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdInActive")]
	public bool? PrdInActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdKind")]
	public int? PrdKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdDefQuantity")]
	public string PrdDefQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdJustDefQuantity")]
	public bool? PrdJustDefQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdMinQuantity")]
	public double? PrdMinQuantity { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelPrdMaxQuantity")]
	public double? PrdMaxQuantity { get; set; }

	public string PrdSHPIsActiveVisibale { get; set; }

	public string PrdSHPTitleVisibale { get; set; }

	public string PrdSHPCodeVisibale { get; set; }

	public string PrdSHPModelVisibale { get; set; }

	public string PrdSHPDescriptionVisibale { get; set; }

	public string PrdSHPDescriptionIIVisibale { get; set; }

	public string PrdSHPStockManageTypeIdVisibale { get; set; }

	public string PrdSHPStockManualyCountVisibale { get; set; }

	public string PrdSHPHiddenPriceInNoStockVisibale { get; set; }

	public string PrdSHPSelfSupplierVisibale { get; set; }

	public string PrdSHPOtherSupplierIdVisibale { get; set; }

	public string PrdSHPQtyFromTracingVisibale { get; set; }

	public string PrdQtyCanDecimalVisibale { get; set; }

	public string PrdCommissionDisableVisibale { get; set; }

	public string PrdCommissionPercentRateVisibale { get; set; }

	public string PrdIsDefaultVisibale { get; set; }

	public string PrdInActiveVisibale { get; set; }

	public string PrdKindVisibale { get; set; }

	public string PrdDefQuantityVisibale { get; set; }

	public string PrdJustDefQuantityVisibale { get; set; }

	public string PrdMinQuantityVisibale { get; set; }

	public string PrdMaxQuantityVisibale { get; set; }

	public string PrdCodeVisibale { get; set; }

	public string PrdNameVisibale { get; set; }

	public string PrdLatinNameVisibale { get; set; }

	public string PrdTypeVisibale { get; set; }

	public string PrdDesignVisibale { get; set; }

	public string PrdSizeVisibale { get; set; }

	public string PrdColorIdVisibale { get; set; }

	public string PrdUnitIdVisibale { get; set; }

	public string PrdMinQtyVisibale { get; set; }

	public string PrdMaxQtyVisibale { get; set; }

	public string PrdSleepDayVisibale { get; set; }

	public string PrdFirstSerialVisibale { get; set; }

	public string PrdSecondSerialVisibale { get; set; }

	public string PrdThirdSerialVisibale { get; set; }

	public string PrdFirstBarcodeVisibale { get; set; }

	public string PrdSecondBarcodeVisibale { get; set; }

	public string PrdThirdBarcodeVisibale { get; set; }

	public string PrdDescriptionVisibale { get; set; }

	public string PrdBarCodeVisibale { get; set; }

	public string PrdBarCodeTypeIdVisibale { get; set; }

	public string PrdAutoNumBarcodeVisibale { get; set; }

	public string PrdAutoNumBarCodeTypeIdVisibale { get; set; }

	public string PrdAutoCharBarcodeVisibale { get; set; }

	public string PrdAutoCharBarCodeTypeIdVisibale { get; set; }

	public string PrdModelVisibale { get; set; }

	public string PrdInactiveInSaleVisibale { get; set; }

	public string PrdInactiveInBuyVisibale { get; set; }

	public string PriceDocDateVisibale { get; set; }

	public string PriceDocNumberVisibale { get; set; }

	public string PriceVisibale { get; set; }

	public string PriceCurrencyPriceVisibale { get; set; }

	public string PriceCurrencyUnitIdVisibale { get; set; }

	public string PriceCooperationPriceVisibale { get; set; }

	public string PricePercentVisibale { get; set; }

	public string PriceDiscountPrecentVisibale { get; set; }

	public string PriceDiscountVisibale { get; set; }

	public string PriceOtherPriceVisibale { get; set; }

	public string PriceDescriptionVisibale { get; set; }

	public string PriceProductPriceGroupIdVisibale { get; set; }

	public string CostDocDateVisibale { get; set; }

	public string CostDocNumberVisibale { get; set; }

	public string CostVisibale { get; set; }

	public string CostCurrencyCostVisibale { get; set; }

	public string CostCurrencyUnitIdVisibale { get; set; }

	public string CostTransportCostVisibale { get; set; }

	public string CostReleasingCostVisibale { get; set; }

	public string CostSlagCostVisibale { get; set; }

	public string CostOtherCostVisibale { get; set; }

	public string CostDescriptionVisibale { get; set; }

	public string CostProductCostGroupIdVisibale { get; set; }

	public bool IsValid { get; set; }

	public bool? Selector { get; set; }

	public bool IsSelect
	{
		get
		{
			if (!Selector.HasValue || Selector == false)
			{
				return false;
			}
			return true;
		}
	}

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelRelationId")]
	public int? RelationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelIsDuplicate")]
	public int? IsDuplicate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelFindedPrdId")]
	public int? FindedPrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelInsertedPrdId")]
	public int? InsertedPrdId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelErrorMessage")]
	public string ErrorMessage { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelDuplicatedIds")]
	public string DuplicatedIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelInsertedPrdPriceId")]
	public string InsertedPriceIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelInsertedPrdCostId")]
	public string InsertedCostIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelUpdatedPrdIds")]
	public string UpdatedPrdIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelUpdatedPriceIds")]
	public string UpdatedPriceIds { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProductImportFromExcelUpdatedCostIds")]
	public string UpdatedCostIds { get; set; }
}
