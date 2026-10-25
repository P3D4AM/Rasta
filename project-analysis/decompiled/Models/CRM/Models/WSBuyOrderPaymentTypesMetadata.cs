using System;

namespace CRM.Models;

public class WSBuyOrderPaymentTypesMetadata
{
	public int BuyOrderPaymentTypeId { get; set; }

	public string bordpayType { get; set; }

	public string bordpayTypeDescription { get; set; }

	public int UserId { get; set; }

	public int? FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
