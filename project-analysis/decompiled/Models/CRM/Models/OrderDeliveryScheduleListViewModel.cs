using System;

namespace CRM.Models;

public class OrderDeliveryScheduleListViewModel
{
	public long? RowNumber { get; set; }

	public string Title { get; set; }

	public string FTime { get; set; }

	public string TTime { get; set; }

	public int Cnt { get; set; }

	public int? UsedCount { get; set; }

	public int? OrderView { get; set; }

	public int? rptUserId { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string rptUserName { get; set; }

	public int? OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public string OrderOpr { get; set; }

	public long? ordNumber { get; set; }

	public string ordDate { get; set; }

	public int ordCompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? ordCompanyPersonId { get; set; }

	public string CompanyPersonName { get; set; }

	public int? ordProjectId { get; set; }

	public string ProjectTitle { get; set; }

	public DateTime? ordDateTime { get; set; }

	public string ordDeliveryDate { get; set; }

	public DateTime? ordDeliveryDateTime { get; set; }

	public string ordDeliveryTime { get; set; }

	public string ordDeliveryEndDate { get; set; }

	public DateTime? ordDeliveryEndDateTime { get; set; }

	public string ordDeliveryEndTime { get; set; }

	public string ordDeliveryDay { get; set; }

	public string ordDeliveryEndDay { get; set; }
}
