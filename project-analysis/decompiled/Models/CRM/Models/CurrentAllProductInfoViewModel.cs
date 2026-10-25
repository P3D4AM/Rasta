using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class CurrentAllProductInfoViewModel
{
	public int ProductId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public List<SelectListItem> TracingList { get; set; }

	public int? CanUpdateBuyOrderItemTracing { get; set; }

	public WSspReturnProductPriceViewModel ProductPrice { get; set; }

	public WSspCmpPrdSalePriceHistory_Result CmpPrdSalePriceNearHistory { get; set; }

	public decimal? ProductUserDiscount { get; set; }

	public WSspReturnProductCost_Result ProductCost { get; set; }

	public WSspCmpPrdBuyCostNearHistory_Result CmpPrdBuyCostNearHistory { get; set; }

	public ReturnPrdQuantityViewModel ProductQuantity { get; set; }

	public WSspPrdSalePriceHistory_Result PrdSalePriceHistory { get; set; }

	public WSspReturnDraftItemQuantityByOrdItemId_Result DraftItemQuantity { get; set; }

	public string LinkedProductIds { get; set; }

	public string ValidityExpireDate { get; set; }

	public string ValidityExpireTime { get; set; }

	public WSspReturnOrderItemQuantityByPordItemId_Result OrderItemQuantity { get; set; }

	public string PrdNickname_Lang { get; set; }

	public string Description_Lang { get; set; }

	public int? DeliveryScheduleTotalCount { get; set; }

	public List<SelectListItem> ListPrdPriceGroup { get; set; }

	public double? CmpGroupIIRate { get; set; }

	public List<SelectListItem> SefareshCodeList { get; set; }

	public WSspReturnBuyOrderItemQuantityByOrdItemId_Result BuyOrderItemQuantity { get; set; }

	public int? PrdDoneTimeMin { get; set; }

	public string PrdSaleCenterIds { get; set; }

	public bool? PrdAutoCalcPrice { get; set; }

	public decimal? PrdAutoCalcItemPrice { get; set; }
}
