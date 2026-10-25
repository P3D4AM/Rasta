using System;

namespace CRM.Models;

public class KyanOrderInfoViewModel
{
	public int? CustomerID { get; set; }

	public string Barcode { get; set; }

	public DateTime BusinessDate { get; set; }

	public string BusinessDateStr { get; set; }

	public string ItemName { get; set; }

	public string ReceiptKyan { get; set; }

	public string ReceiptNo { get; set; }

	public int InventoryID { get; set; }

	public string InventoryName { get; set; }

	public int RetailStoreID { get; set; }

	public string RetailStoreName { get; set; }

	public decimal? RetDiscountAmounturnAmount { get; set; }

	public decimal? ReturnAmount { get; set; }

	public decimal? ReturnChargeAmount { get; set; }

	public decimal? ReturnDiscountAmount { get; set; }

	public decimal? ReturnQuantity { get; set; }

	public decimal? ReturnTaxAmount { get; set; }

	public decimal SaleAmount { get; set; }

	public decimal? SaleChargeAmount { get; set; }

	public decimal? SaleQuantity { get; set; }

	public decimal? SaleTaxAmount { get; set; }

	public int OrderId { get; set; }

	public long RowNumber { get; set; }

	public string BusinessDate_Persian { get; set; }

	public DateTime BusinessDate_DateTime { get; set; }

	public string BusinessDate_Time { get; set; }
}
