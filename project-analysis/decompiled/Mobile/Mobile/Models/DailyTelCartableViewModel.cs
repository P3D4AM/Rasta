using System.Collections.Generic;

namespace Mobile.Models;

public class DailyTelCartableViewModel
{
	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public string FilePath { get; set; }

	public int? CallTypeId { get; set; }

	public int? LineNumber { get; set; }

	public int? CallHistoryId { get; set; }

	public string RequestDate { get; set; }

	public string CompanyName { get; set; }

	public string PersonName { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }

	public int CountPage { get; set; }
}
