using System.Collections.Generic;

namespace CRM.Models;

public class CmpOrderStockAccListViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public long TotalPage { get; set; }

	public List<CmpOrderStockAccViewModel> ResultList { get; set; }
}
