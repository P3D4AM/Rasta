using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCostSheetItemsMetadata))]
public class WSCostSheetItems
{
	public int CostSheetItemId { get; set; }

	public int CostSheetId { get; set; }

	public int CostSheetProductId { get; set; }

	public double ctshIQuantity { get; set; }

	public double? ctshIWeight { get; set; }

	public decimal? ctshICost { get; set; }

	public decimal? ctshITotalCost { get; set; }

	public decimal? ctshIDesctCurrencyCost { get; set; }

	public decimal? ctshIDesctCurrencyTotalCost { get; set; }

	public decimal? ctshIPrice { get; set; }

	public decimal? ctshIPriceRounded { get; set; }

	public decimal? ctshITotalPrice { get; set; }

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

	public double? ctshIRoundRate { get; set; }

	public int? ctshIBuyOrderId { get; set; }

	public int? ctshIBuyOrderItemId { get; set; }

	public int? ctshIPreOrderItemId { get; set; }

	public double? ctshILength { get; set; }

	public double? ctshIWidth { get; set; }

	public int? ctshICId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrder WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual WSBuyOrderItems WSBuyOrderItems1 { get; set; }

	public virtual WSCostSheetProducts WSCostSheetProducts { get; set; }

	public virtual WSCostSheets WSCostSheets { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSPreOrderItems WSPreOrderItems { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems1 { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSCostSheetItems()
	{
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSPreOrderItems1 = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
	}
}
