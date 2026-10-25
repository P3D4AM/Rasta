using System;

namespace CRM.Models;

public class CRMspLkSepWSSelectDocFromSep_Result
{
	public int? InventoryId { get; set; }

	public bool? IsReturn { get; set; }

	public int? Type { get; set; }

	public int? StockRef { get; set; }

	public string Stock { get; set; }

	public int? DestinationStockRef { get; set; }

	public string DestinationStock { get; set; }

	public int? CustomerDlId { get; set; }

	public string Customer { get; set; }

	public int? Number { get; set; }

	public DateTime? Date { get; set; }

	public decimal? TotalPrice { get; set; }

	public int? FiscalYearRef { get; set; }

	public DateTime? CreationDate { get; set; }

	public DateTime? LastModificationDate { get; set; }

	public int? BasePurchaseInvoiceRef { get; set; }

	public int? BasePurchaseInvoiceNumber { get; set; }

	public int? VoucherRef { get; set; }

	public int? VoucherNumber { get; set; }

	public int? ItemCount { get; set; }

	public int? DocId { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }

	public int? StockWHId { get; set; }

	public int? DestinationStockWHId { get; set; }
}
