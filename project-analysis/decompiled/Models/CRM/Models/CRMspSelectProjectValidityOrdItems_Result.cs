using System;

namespace CRM.Models;

public class CRMspSelectProjectValidityOrdItems_Result
{
	public int OrderItemID { get; set; }

	public int OrderId { get; set; }

	public int ordIPrdId { get; set; }

	public double? ordIQuantity { get; set; }

	public decimal? ordITotalPrice { get; set; }

	public DateTime? ordIValidityExpireDate { get; set; }

	public string ordIValidityExpireDatePersian { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public long? ordNumber { get; set; }

	public string ordDate { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string OrderOpr { get; set; }
}
