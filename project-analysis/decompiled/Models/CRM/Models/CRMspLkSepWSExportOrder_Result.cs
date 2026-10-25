using System;

namespace CRM.Models;

public class CRMspLkSepWSExportOrder_Result
{
	public int? OrderID { get; set; }

	public long? ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? OrderOprID { get; set; }

	public int? ordLinkAccCodeId { get; set; }

	public string ordLinkAccCode { get; set; }

	public int? ordLinkAccOrderId { get; set; }

	public string ordLinkAccOrderNumber { get; set; }

	public int? ordLinkAccVoucherId { get; set; }

	public string ordLinkAccVoucherNumber { get; set; }

	public string ordLinkAccOrderIdStr { get; set; }

	public string ErrorMessage { get; set; }
}
