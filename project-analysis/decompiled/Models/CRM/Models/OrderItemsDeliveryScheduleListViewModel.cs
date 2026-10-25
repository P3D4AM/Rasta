using System;

namespace CRM.Models;

public class OrderItemsDeliveryScheduleListViewModel
{
	public long? RowNumber { get; set; }

	public string Title { get; set; }

	public string FTime { get; set; }

	public string TTime { get; set; }

	public int? Cnt { get; set; }

	public int? UsedCount { get; set; }

	public int? PrdId { get; set; }

	public int? OrderView { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public int? PrdSGId { get; set; }

	public string PrdSGName { get; set; }

	public int? PrdFGId { get; set; }

	public string PrdFGName { get; set; }

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

	public DateTime? ordIDeliveryDate { get; set; }

	public string ordIDeliveryDatePersian { get; set; }

	public string ordIDeliveryTime { get; set; }

	public string ordIDeliveryDay { get; set; }

	public DateTime? ordIDeliveryEndDate { get; set; }

	public string ordIDeliveryEndDatePersian { get; set; }

	public string ordIDeliveryEndTime { get; set; }

	public string ordIDeliveryEndDay { get; set; }
}
