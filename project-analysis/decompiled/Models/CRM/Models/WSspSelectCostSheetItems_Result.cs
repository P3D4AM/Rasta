using System;

namespace CRM.Models;

public class WSspSelectCostSheetItems_Result
{
	public int CostSheetItemId { get; set; }

	public int CostSheetId { get; set; }

	public int CostSheetProductId { get; set; }

	public string CostSheetProduct { get; set; }

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

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public double? ctshIRoundRate { get; set; }

	public int? ctshIBuyOrderId { get; set; }

	public int? ctshIBuyOrderItemId { get; set; }

	public int? ctshIPreOrderItemId { get; set; }

	public long? bordNumber { get; set; }

	public int? bordReferUserId { get; set; }

	public string bordReferUser { get; set; }

	public string bordDate { get; set; }

	public int? bordCompanyId { get; set; }

	public string bordCompany { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public DateTime? bordDateTime { get; set; }

	public int? bordCurrencyUnitId { get; set; }

	public string bordCurrencyUnit { get; set; }

	public int? bordFacilityCmpId { get; set; }

	public string bordFacilityCmp { get; set; }

	public int? bordReqCmpId { get; set; }

	public string bordReqCmp { get; set; }

	public decimal? bordTotalFinalCost { get; set; }

	public int? ctshPrdGroupId { get; set; }

	public string ctshPrdGroup { get; set; }

	public string bordNumRef { get; set; }

	public double? ctshILength { get; set; }

	public double? ctshIWidth { get; set; }
}
