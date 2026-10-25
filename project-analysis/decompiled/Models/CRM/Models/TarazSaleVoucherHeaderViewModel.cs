using System;

namespace CRM.Models;

public class TarazSaleVoucherHeaderViewModel
{
	public long? saleCenterID { get; set; }

	public long? deliverCenterID { get; set; }

	public long? paymentWayID { get; set; }

	public string voucherDesc { get; set; }

	public long? marketingManID { get; set; }

	public long? saleTypeID { get; set; }

	public string voucherDate { get; set; }

	public string vocherTime { get; set; }

	public DateTime? voucherDateG { get; set; }

	public long? voucherHeaderID { get; set; }

	public long? voucherTypeID { get; set; }

	public long? customerID { get; set; }

	public long? storeID { get; set; }

	public long? salesManID { get; set; }

	public int? dayCount { get; set; }
}
