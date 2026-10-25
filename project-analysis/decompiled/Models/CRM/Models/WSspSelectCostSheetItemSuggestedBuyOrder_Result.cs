using System;

namespace CRM.Models;

public class WSspSelectCostSheetItemSuggestedBuyOrder_Result
{
	public int BuyOrderID { get; set; }

	public int? BuyOrderOprId { get; set; }

	public string BuyOrderOpr { get; set; }

	public long bordNumber { get; set; }

	public string bordDate { get; set; }

	public int bordCompanyId { get; set; }

	public int? bordCompanyPersonId { get; set; }

	public string bordCompany { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public string bordTotalAmountStr { get; set; }

	public int? bordReferUserId { get; set; }

	public string bordReferUser { get; set; }

	public DateTime? bordDateTime { get; set; }

	public int? bordCurrencyUnitId { get; set; }

	public string bordCurrencyUnit { get; set; }

	public int? bordFacilityCmpId { get; set; }

	public int? bordFacilityPrsId { get; set; }

	public string bordFacilityCmp { get; set; }

	public int? bordReqCmpId { get; set; }

	public int? bordReqPrsId { get; set; }

	public string bordReqCmp { get; set; }

	public decimal? bordTotalFinalCost { get; set; }

	public decimal? bordITotalCost { get; set; }

	public decimal? bordICostSum { get; set; }

	public decimal? bordITotalFinalCost { get; set; }

	public string bordNumRef { get; set; }
}
