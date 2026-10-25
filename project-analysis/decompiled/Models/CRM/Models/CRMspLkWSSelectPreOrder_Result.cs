using System;

namespace CRM.Models;

public class CRMspLkWSSelectPreOrder_Result
{
	public int PreOrderID { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public int? pordProjectId { get; set; }

	public int? pordItemCount { get; set; }

	public decimal? pordItemsAmount { get; set; }

	public decimal? pordInstallAmount { get; set; }

	public decimal? pordDiscount { get; set; }

	public decimal? pordSumAmount { get; set; }

	public decimal? pordTax { get; set; }

	public decimal? pordTaxIndex { get; set; }

	public bool? pordCalculateTax { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public string pordTotalAmountStr { get; set; }

	public int? pordReferUserId { get; set; }

	public DateTime? pordDateTime { get; set; }

	public decimal? pordTransportation { get; set; }

	public decimal? pordDiscountPercent { get; set; }

	public decimal? pordRound { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyName { get; set; }

	public string CompanyPerson { get; set; }

	public string ProjectTitle { get; set; }

	public string pordReferUser { get; set; }

	public int? pordLinkAccPreOrderId { get; set; }

	public string pordLinkAccPreOrderNumber { get; set; }

	public long? RowNumber { get; set; }

	public Guid? GUId { get; set; }

	public string pordLinkAccPreOrderIdStr { get; set; }

	public string pordDescriptionI { get; set; }

	public string pordDescriptionII { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string pordLinkAccData { get; set; }

	public int? pordSaleCenterId { get; set; }

	public string pordSaleCenter { get; set; }

	public string LinkAccSaleCenterIdStr { get; set; }

	public string SaleCenterLinkAccData { get; set; }

	public string ListItemRecords { get; set; }
}
