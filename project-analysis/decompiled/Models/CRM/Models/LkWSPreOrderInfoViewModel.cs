using System;

namespace CRM.Models;

public class LkWSPreOrderInfoViewModel
{
	public long RowNumber { get; set; }

	public int PreOrderID { get; set; }

	public string pordDate { get; set; }

	public decimal? pordDiscount { get; set; }

	public decimal? pordTax { get; set; }

	public decimal? pordTaxIndex { get; set; }

	public bool? pordCalculateTax { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public string pordDescriptionI { get; set; }

	public string pordDescriptionII { get; set; }

	public decimal? pordTransportation { get; set; }

	public decimal? pordDiscountPercent { get; set; }

	public string pordDiscountTitle { get; set; }

	public decimal? pordRound { get; set; }

	public DateTime? pordDateTime { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public string pordExpireDate { get; set; }

	public DateTime? pordExpireDateTime { get; set; }

	public int? pordPayConditionId { get; set; }

	public string pordLinkAccData { get; set; }

	public int pordCompanyId { get; set; }

	public string cmpName { get; set; }

	public string cmpLinkAccCode { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public string DeliveryTerm { get; set; }

	public string LinkAccDeliveryTermIdStr { get; set; }

	public string SaleCenterName { get; set; }

	public string LinkAccSaleCenterIdStr { get; set; }

	public string LinkAccReferUserIdStr { get; set; }

	public string LinkAccReferUserCode { get; set; }

	public string ReferUserFName { get; set; }

	public string ReferUserLName { get; set; }

	public string SellerUserFName { get; set; }

	public string SellerUserLName { get; set; }

	public string LinkAccSellerUserIdStr { get; set; }

	public string LinkAccSellerUserCode { get; set; }

	public string CurrencyUnit { get; set; }

	public string LinkAccCurrencyUnitIdStr { get; set; }

	public string PreOrderType { get; set; }

	public string LinkAccPreOrderTypeIdStr { get; set; }

	public string PreOrderOpr { get; set; }

	public string LinkAccPreOrderOprIdStr { get; set; }

	public string ListItemRecords { get; set; }
}
