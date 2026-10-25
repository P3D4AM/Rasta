using System.Collections.Generic;

namespace CRM.Models;

public class CrmProjectFieldTitleViewModel
{
	public CRMspSelectProjectFieldTitle_Result Info { get; set; }

	public int CurrentId { get; set; }

	public int NextId { get; set; }

	public int PreviousId { get; set; }

	public int FirstId { get; set; }

	public int LastId { get; set; }

	public string Message { get; set; }

	public bool IsFind { get; set; }

	public List<CRMspSelectProjectFieldTitle_Result> GridList { get; set; }
}
