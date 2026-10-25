using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.OrderItemsDeliverySchedulePrintRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public DateTime DeliveryDate { get; set; }

	public string DeliveryDatePersian { get; set; }

	public int DeliveryDay { get; set; }

	public string DeliveryDayName { get; set; }

	public List<WSspRpt_OrderItemsDeliverySchedule_Result> NotUsed_ListWSspRpt_OrderItemsDeliverySchedule { get; set; }

	public List<OrderItemsDeliveryScheduleListViewModel> NotUsed_ListWSspRpt_OrderList { get; set; }
}
