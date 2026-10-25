using System.Collections.Generic;

namespace CRM.Models;

public class CmpOrderAccViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public long TotalPage { get; set; }

	public List<WSspRpt_CmpOrderAcc_Result> ResultList { get; set; }
}
