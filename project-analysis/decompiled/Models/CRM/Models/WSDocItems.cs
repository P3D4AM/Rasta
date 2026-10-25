using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDocItemsMetadata))]
public class WSDocItems
{
	public int DocItemID { get; set; }

	public int DocId { get; set; }

	public int PrdId { get; set; }

	public double? Quantity { get; set; }

	public int? CostId { get; set; }

	public decimal? Cost { get; set; }

	public string Description { get; set; }

	public short? IsFix { get; set; }

	public int? WHId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public bool? NotVisible { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public double? FCR { get; set; }

	public double? FCRI { get; set; }

	public int? DocILinkAccItemId { get; set; }

	public string Tracing { get; set; }

	public string DocILinkAccItemIdStr { get; set; }

	public int? PrdUnitId { get; set; }

	public double? QuantityTotal { get; set; }

	public int? PrdUnitIdI { get; set; }

	public double? PrdUnitIRateResult { get; set; }

	public string PrdNickname { get; set; }

	public DateTime? DocILinkAccFirstTransferDate { get; set; }

	public DateTime? DocILinkAccLastTransferDate { get; set; }

	public int? PreOrderItemId { get; set; }

	public string OrderItemIds { get; set; }

	public int? BuyOrderItemId { get; set; }

	public string DocILinkAccData { get; set; }

	public int? DocICId { get; set; }

	public double? PrdWeight { get; set; }

	public int? DocILinkAccSettingDBId { get; set; }

	public int? PrdUnitIdII { get; set; }

	public double? PrdUnitIIRateResult { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrderItems WSBuyOrderItems { get; set; }

	public virtual WSDoc WSDoc { get; set; }

	public virtual ICollection<WSDocItems_Lang> WSDocItems_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSPreOrderItems WSPreOrderItems { get; set; }

	public virtual WSProductCost WSProductCost { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual WSProductUnits WSProductUnits { get; set; }

	public virtual WSProductUnits WSProductUnits1 { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual ICollection<WSDocItemSerials> WSDocItemSerials { get; set; }

	public virtual WSProductUnits WSProductUnits2 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSDocItems()
	{
		WSDocItems_Lang = (ICollection<WSDocItems_Lang>)new HashSet<WSDocItems_Lang>();
		WSDocItemSerials = (ICollection<WSDocItemSerials>)new HashSet<WSDocItemSerials>();
	}
}
