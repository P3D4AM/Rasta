using System.Collections.Generic;

namespace CRM.Models;

public class OrdItemsDeliveryScheduleListViewModel
{
	public long TotalRow { get; set; }

	public List<WSspRpt_OrderItemsDeliverySchedule_Result> ResultList { get; set; }

	public List<OrderItemsDeliveryScheduleListViewModel> ResultOrderList { get; set; }
}
