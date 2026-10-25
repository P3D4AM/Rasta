using System;

namespace Mobile.Models;

public class SHPMobspSelectOrdersByCmpId_Result
{
	public long? Rownum { get; set; }

	public int? AllPage { get; set; }

	public int OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public int? PreOrderId { get; set; }

	public int? PreOrderVerifierId { get; set; }

	public string ordTitle { get; set; }

	public long ordNumber { get; set; }

	public string ordDate { get; set; }

	public int ordCompanyId { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public int? ordProjectId { get; set; }

	public decimal? ordTotalAmount { get; set; }

	public bool? ordIsVerified { get; set; }

	public bool? ordIsFixed { get; set; }

	public DateTime? ordDateTime { get; set; }

	public int? ordReferUserId { get; set; }

	public string ordDeliveryDate { get; set; }

	public DateTime? ordDeliveryDateTime { get; set; }

	public string ordDeliveryTime { get; set; }

	public string ordDeliveryEndDate { get; set; }

	public DateTime? ordDeliveryEndDateTime { get; set; }

	public string ordDeliveryEndTime { get; set; }

	public string ordCompany { get; set; }

	public string ordCompanyPerson { get; set; }

	public string ordProject { get; set; }

	public string ordReferUser { get; set; }
}
