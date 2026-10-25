namespace CRM.Models;

public class WSProductImportFromExcelMetadata
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
}
