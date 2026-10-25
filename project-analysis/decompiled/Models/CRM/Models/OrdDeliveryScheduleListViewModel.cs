using System.Collections.Generic;

namespace CRM.Models;

public class OrdDeliveryScheduleListViewModel
{
	public long TotalRow { get; set; }

	public List<WSspRpt_OrderDeliverySchedule_Result> ResultList { get; set; }

	public List<OrderDeliveryScheduleListViewModel> ResultOrderList { get; set; }
}
