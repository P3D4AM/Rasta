namespace CRM.Models;

public class WSspRpt_PrintDocItemsFromQuantity_Result
{
	public int DocItemID { get; set; }

	public int DocId { get; set; }

	public int PrdId { get; set; }

	public string PrdNMBL { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdFGName { get; set; }

	public string PrdFGNameEn { get; set; }

	public string PrdSGName { get; set; }

	public string PrdSGNameEn { get; set; }

	public string PrdGroup { get; set; }

	public string PrdGroupEn { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdModel { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public string PrdColor { get; set; }

	public string PrdColorEn { get; set; }

	public string PrdUnit { get; set; }

	public string PrdUnitEn { get; set; }

	public string PrdPriceCurrencyUnit { get; set; }

	public string PrdPriceCurrencyUnitEn { get; set; }

	public string PrdCostCurrencyUnit { get; set; }

	public string PrdCostCurrencyUnitEn { get; set; }

	public double? Quantity { get; set; }

	public int? CostId { get; set; }

	public decimal? Cost { get; set; }

	public string DIDescription { get; set; }

	public double? PrdUnitFCR { get; set; }

	public double? FCR { get; set; }

	public double? FCRI { get; set; }

	public int? DocILinkAccItemId { get; set; }

	public string Tracing { get; set; }

	public string PrdManufacturerName { get; set; }

	public string PrdManufacturerCode { get; set; }

	public int? docIPrdUnitId { get; set; }

	public string docIPrdUnit { get; set; }

	public double? QuantityTotal { get; set; }

	public int? PrdUnitIdI { get; set; }

	public string PrdUnitI { get; set; }

	public double? PrdUnitIRateResult { get; set; }

	public string PrdNickname { get; set; }

	public byte[] PrdFirstPic { get; set; }

	public int? ordIPrdColorId { get; set; }

	public string ordIPrdColor { get; set; }

	public int? pordIPrdColorId { get; set; }

	public string pordIPrdColor { get; set; }

	public int? bordIPrdColorId { get; set; }

	public string bordIPrdColor { get; set; }

	public decimal? LastPrdPrice { get; set; }

	public string PrdLocation { get; set; }

	public double? PrdWeight { get; set; }

	public int? DocICId { get; set; }

	public string DocICenterName { get; set; }

	public double? DocIPrdWeight { get; set; }

	public int? PrdUnitIdII { get; set; }

	public string PrdUnitII { get; set; }

	public double? PrdUnitIIRateResult { get; set; }
}
