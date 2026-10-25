using System;

namespace Mobile.Models;

public class MobspSelectExpiredPreOrders_Result
{
	public long? Rownum { get; set; }

	public int PreOrderID { get; set; }

	public string pordTitle { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordCompanyId { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public int? pordProjectId { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public bool? pordIsVerified { get; set; }

	public bool? pordIsFixed { get; set; }

	public long? pordNumberRevision { get; set; }

	public int? pordReferUserId { get; set; }

	public string pordDeliveryDate { get; set; }

	public DateTime? pordDeliveryDateTime { get; set; }

	public string pordDeliveryTime { get; set; }

	public string pordDeliveryEndDate { get; set; }

	public DateTime? pordDeliveryEndDateTime { get; set; }

	public string pordDeliveryEndTime { get; set; }

	public DateTime? pordExpireDateTime { get; set; }

	public string pordCompany { get; set; }

	public string pordCompanyPerson { get; set; }

	public string pordProject { get; set; }

	public string pordReferUser { get; set; }

	public int? AllPage { get; set; }
}
