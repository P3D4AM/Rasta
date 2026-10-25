using System;

namespace Mobile.Models;

public class ShopIssueOrderViewModel
{
	public string PrdDoneTimeJs { get; set; }

	public int CompanyId { get; set; }

	public string Items { get; set; }

	public decimal Transportation { get; set; }

	public int PersonId { get; set; }

	public int WHId { get; set; }

	public int PrjcnvsStatusGroupId { get; set; }

	public int OrdCurrencyUnitId { get; set; }

	public int OrdVerifierRequestId { get; set; }

	public string OrdDeliveryEndDate { get; set; }

	public string OrdDeliveryDate { get; set; }

	public DateTime? OrdDeliveryDateTime { get; set; }

	public string OrdDeliveryEndTime { get; set; }

	public DateTime? OrdDeliveryEndDateTime { get; set; }

	public string OrdDeliveryTime { get; set; }

	public string ProductDiscountJson { get; set; }

	public int? DiscountCodeId { get; set; }

	public string DisCode { get; set; }

	public decimal DisAmount { get; set; }

	public decimal DisAmountPercent { get; set; }

	public string OrdDiscountTitle { get; set; }

	public string OrdDescription { get; set; }

	public int DeliveryTermId { get; set; }

	public int? LanguageId { get; set; }

	public int PordExpireDay { get; set; }

	public int? CenterId { get; set; }

	public int? FoSettingId { get; set; }

	public int? ShpCartPayTypeId { get; set; }

	public string ItemWeightToleranceJson { get; set; }

	public int? SaleAreaId { get; set; }
}
