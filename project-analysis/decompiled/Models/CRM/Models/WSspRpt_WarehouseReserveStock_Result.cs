namespace CRM.Models;

public class WSspRpt_WarehouseReserveStock_Result
{
	public int FPId { get; set; }

	public string UserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public int PrdId { get; set; }

	public int? WHId { get; set; }

	public double? pordIFCR { get; set; }

	public double? pordIFCRI { get; set; }

	public double? PrdUnitFCR { get; set; }

	public string Tracing { get; set; }

	public string WrhsName { get; set; }

	public string WrhsCode { get; set; }

	public string FGCode { get; set; }

	public string FGName { get; set; }

	public string SGCode { get; set; }

	public string SGName { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdModel { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public int? FGId { get; set; }

	public int SGId { get; set; }

	public decimal? LastPrdPrice { get; set; }

	public string PrdColor { get; set; }

	public string PrdUnit { get; set; }

	public double? InQuantity { get; set; }

	public double? OutQuantity { get; set; }

	public double? ValidpordQuantity { get; set; }

	public double RemainQuantity { get; set; }

	public double RemainValidPordQuantity { get; set; }

	public string PrdUnitI { get; set; }

	public double? PrdUnitIFCR { get; set; }

	public decimal? LastPrdCurrencyPrice { get; set; }

	public string PrdUnitII { get; set; }

	public double? PrdUnitIIFCR { get; set; }

	public double? InPrdUnitIRateResult { get; set; }

	public double? OutPrdUnitIRateResult { get; set; }

	public double? ValidpordPrdUnitIRateResult { get; set; }

	public double? InPrdUnitIIRateResult { get; set; }

	public double? OutPrdUnitIIRateResult { get; set; }

	public double? ValidpordPrdUnitIIRateResult { get; set; }

	public double? RemainPrdUnitIRateResult { get; set; }

	public double? RemainValidPordPrdUnitIRateResult { get; set; }

	public double? RemainPrdUnitIIRateResult { get; set; }

	public double? RemainValidPordPrdUnitIIRateResult { get; set; }
}
