using System;

namespace CRM.Models;

public class CRMspSelectSysPendingOperations_Result
{
	public int PendingOperationID { get; set; }

	public string poOperate { get; set; }

	public DateTime? poOperateDate { get; set; }

	public string poOperateDatePersian { get; set; }

	public string poCommand { get; set; }

	public string poResult { get; set; }

	public DateTime? poResultDate { get; set; }

	public string poResultDatePersian { get; set; }

	public DateTime? poStartDate { get; set; }

	public string poStartDatePersian { get; set; }

	public DateTime? poFinishDate { get; set; }

	public string poFinishDatePersian { get; set; }
}
