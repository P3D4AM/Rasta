using System.Collections.Generic;

namespace CRM.Models;

public class TSPSelectOrderListViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public long TotalPage { get; set; }

	public List<TSPspSelectOrder_Result> ResultList { get; set; }
}
