using System;

namespace CRM.Models;

public class WSspSelectStockSupplyItems_Result
{
	public int StockSupplyItemId { get; set; }

	public int StockSupplyId { get; set; }

	public int stsupIPrdId { get; set; }

	public string stsupIPrdName { get; set; }

	public string stsupIPrdCode { get; set; }

	public bool? stsupISingleItem { get; set; }

	public string stsupIPrdFGName { get; set; }

	public string stsupIPrdSGName { get; set; }

	public double stsupIQuantity { get; set; }

	public string stsupIDescription { get; set; }

	public string stsupIQuantityDesc { get; set; }

	public int? stsupIPrdUnitId { get; set; }

	public string stsupIPrdUnit { get; set; }

	public int? stsupIOrderView { get; set; }

	public double? stsupIFCR { get; set; }

	public double? stsupIFCRI { get; set; }

	public int? stsupIWHId { get; set; }

	public string stsupIWrhsName { get; set; }

	public string stsupITracing { get; set; }

	public int? stsupIPrdUnitIdI { get; set; }

	public string stsupIPrdUnitI { get; set; }

	public double? stsupIPrdUnitIRateResult { get; set; }

	public double? stsupIPrdUnitIRate { get; set; }

	public int? stsupIPrdColorId { get; set; }

	public string stsupIPrdColor { get; set; }

	public string stsupIPrdNickname { get; set; }

	public int? stsupIPreOrderId { get; set; }

	public int? stsupIPreOrderItemId { get; set; }

	public double? pordIQuantity { get; set; }

	public double? pordIFCR { get; set; }

	public double? pordIFCRI { get; set; }

	public string stsupIBuyOrderIds { get; set; }

	public string stsupIBuyOrders { get; set; }

	public string stsupIBuyOrderItemIds { get; set; }

	public string stsupIBuyOrderItems { get; set; }

	public string stsupILinkAccWHIdStr { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string PrdRowColor { get; set; }

	public int? stsupILinkAccSettingDBId { get; set; }

	public decimal? stsupICost { get; set; }

	public double? stsupIPrdWeight { get; set; }
}
