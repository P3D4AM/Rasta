namespace CRM.Models;

public class WSspRpt_OrderDeliverySchedule_Result
{
	public long? RowNumber { get; set; }

	public string Title { get; set; }

	public string FTime { get; set; }

	public string TTime { get; set; }

	public int Cnt { get; set; }

	public int? UsedCount { get; set; }

	public int? OrderView { get; set; }

	public string OrderList { get; set; }

	public int? rptUserId { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string rptUserName { get; set; }
}
