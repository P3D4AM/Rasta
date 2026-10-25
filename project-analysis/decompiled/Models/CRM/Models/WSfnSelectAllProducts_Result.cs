using System;

namespace CRM.Models;

public class WSfnSelectAllProducts_Result
{
	public int ProductID { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public int PrdGroupID { get; set; }

	public string FGCode { get; set; }

	public string FGName { get; set; }

	public string FGNameEn { get; set; }

	public string SGCode { get; set; }

	public string SGName { get; set; }

	public string SGNameEn { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdModel { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public int? PrdColorId { get; set; }

	public string PrdColor { get; set; }

	public string PrdColorEn { get; set; }

	public int? PrdUnitId { get; set; }

	public string PrdUnit { get; set; }

	public string PrdUnitEn { get; set; }

	public double? PrdUnitFCR { get; set; }

	public int? PrdUnitQuantityInUnit { get; set; }

	public string PrdFirstSerial { get; set; }

	public string PrdSecondSerial { get; set; }

	public string PrdThirdSerial { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdSecondBarcode { get; set; }

	public string PrdThirdBarcode { get; set; }

	public string PrdDescription { get; set; }

	public int? PrdMinQty { get; set; }

	public int? PrdMaxQty { get; set; }

	public int? PrdSleepDay { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? PrdPriceCurrencyUnitId { get; set; }

	public string PrdPriceCurrencyUnit { get; set; }

	public string PrdPriceCurrencyUnitEn { get; set; }

	public int? PrdCostCurrencyUnitId { get; set; }

	public string PrdCostCurrencyUnit { get; set; }

	public string PrdCostCurrencyUnitEn { get; set; }
}
