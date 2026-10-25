using System;

namespace CRM.Models;

public class LkWSOrderInfoViewModel
{
	public long RowNumber { get; set; }

	public int OrderID { get; set; }

	public string ordDate { get; set; }

	public decimal? ordDiscount { get; set; }

	public decimal? ordTax { get; set; }

	public decimal? ordTaxIndex { get; set; }

	public bool? ordCalculateTax { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public string ordDescriptionI { get; set; }

	public string ordDescriptionII { get; set; }

	public decimal? ordTransportation { get; set; }

	public decimal? ordDiscountPercent { get; set; }

	public string ordDiscountTitle { get; set; }

	public decimal? ordRound { get; set; }

	public string ordNote { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccTransferKey { get; set; }

	public string ordLinkAccTransferResult { get; set; }

	public string ordLinkAccData { get; set; }

	public int ordCompanyId { get; set; }

	public string cmpName { get; set; }

	public string cmpLinkAccCode { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public string DeliveryTerm { get; set; }

	public string LinkAccDeliveryTermIdStr { get; set; }

	public string SaleCenterName { get; set; }

	public string LinkAccSaleCenterIdStr { get; set; }

	public int? ordSettlementTypeId { get; set; }

	public string SettlementType { get; set; }

	public string LinkAccSettlementTypeIdStr { get; set; }

	public string LinkAccReferUserIdStr { get; set; }

	public string LinkAccReferUserCode { get; set; }

	public string ReferUserFName { get; set; }

	public string ReferUserLName { get; set; }

	public string CurrencyUnit { get; set; }

	public string LinkAccCurrencyUnitIdStr { get; set; }

	public string OrderGroupName { get; set; }

	public string LinkAccGroupIdStr { get; set; }

	public string OrderOprName { get; set; }

	public string LinkAccOrderOprIdStr { get; set; }

	public string ListItemRecords { get; set; }
}
