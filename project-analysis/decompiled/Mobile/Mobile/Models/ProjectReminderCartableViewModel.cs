using System.Collections.Generic;

namespace Mobile.Models;

public class ProjectReminderCartableViewModel
{
	public int? ProjectId { get; set; }

	public int? CompanyId { get; set; }

	public string CompanyName { get; set; }

	public string ProjectName { get; set; }

	public int? StatusGroupId { get; set; }

	public string RemindDate { get; set; }

	public string RemindDatePersian { get; set; }

	public bool? IsFinished { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }

	public int CountPage { get; set; }
}
