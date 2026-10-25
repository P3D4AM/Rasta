using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSStockSupplyItemsMetadata))]
public class WSStockSupplyItems
{
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

	public int? stsupICId { get; set; }

	public double? stsupIPrdWeight { get; set; }

	public int? stsupILinkAccSettingDBId { get; set; }

	public decimal? stsupICost { get; set; }

	public int? stsupIPrdUnitIdII { get; set; }

	public double? stsupIPrdUnitIIRateResult { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual WSPreOrderItems WSPreOrderItems { get; set; }

	public virtual WSProductColor WSProductColor { get; set; }

	public virtual WSProductUnits WSProductUnits { get; set; }

	public virtual WSProductUnits WSProductUnits1 { get; set; }

	public virtual WSStockSupply WSStockSupply { get; set; }

	public virtual ICollection<WSStockSupplyItems_Lang> WSStockSupplyItems_Lang { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual WSProductUnits WSProductUnits2 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSStockSupplyItems()
	{
		WSStockSupplyItems_Lang = (ICollection<WSStockSupplyItems_Lang>)new HashSet<WSStockSupplyItems_Lang>();
	}
}
