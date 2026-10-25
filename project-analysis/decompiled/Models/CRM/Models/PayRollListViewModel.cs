using System.Collections.Generic;

namespace CRM.Models;

public class PayRollListViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public List<PayRollspSelectActiveItems_Result> PayRollItems { get; set; }

	public List<PayRollspSelectListWithMonth_Result> PayRollList { get; set; }

	public List<PayRollspSelectListItems_Result> PayRollListItems { get; set; }

	public List<PayRollspSelectUserCycleItemValuesWithListId_Result> PayRollListItemValues { get; set; }
}
