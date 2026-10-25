using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSStockSupplyItemsMetadata
{
	[Key]
	public int StockSupplyItemId { get; set; }

	public int StockSupplyId { get; set; }

	public int stsupIPrdId { get; set; }

	public double stsupIQuantity { get; set; }

	public string stsupIDescription { get; set; }

	public string stsupIQuantityDesc { get; set; }

	public int? stsupIPrdUnitId { get; set; }

	public int? stsupIOrderView { get; set; }

	public double? stsupIFCR { get; set; }

	public double? stsupIFCRI { get; set; }

	public int? stsupIWHId { get; set; }

	public string stsupITracing { get; set; }

	public int? stsupIPrdUnitIdI { get; set; }

	public double? stsupIPrdUnitIRateResult { get; set; }

	public int? stsupIPrdColorId { get; set; }

	public string stsupIPrdNickname { get; set; }

	public int? stsupIPreOrderId { get; set; }

	public int? stsupIPreOrderItemId { get; set; }

	public string stsupIBuyOrderIds { get; set; }

	public string stsupIBuyOrderItemIds { get; set; }

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
}
