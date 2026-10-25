using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSCostSheetItemsMetadata
{
	[Key]
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

	public int? ctshIPreOrderItemId { get; set; }

	public int? ctshIBuyOrderItemId { get; set; }
}
