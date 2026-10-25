using System.Collections.Generic;

namespace CRM.Models;

public class ArianSystemSaleFactorRequestViewModel
{
	public string CustomerId { get; set; }

	public string SecCustomerId { get; set; }

	public string SaleTypeID { get; set; }

	public string StockID { get; set; }

	public string SaleCenterID { get; set; }

	public string DeliveryCenterID { get; set; }

	public string SellerID { get; set; }

	public string SaleManID { get; set; }

	public string PaymentWayID { get; set; }

	public string PayWayDays { get; set; }

	public string VoucherDesc { get; set; }

	public string DistributerId { get; set; }

	public string VoucherNumber { get; set; }

	public string VoucherDate { get; set; }

	public int isrow { get; set; }

	public int __IsTemp__ { get; set; }

	public string SecondNumber { get; set; }

	public List<ArianSystemSaleFactorItemsRequestViewModel> Items { get; set; }
}
