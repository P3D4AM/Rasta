using System.Collections.Generic;

namespace Mobile.Models;

public class UserTaskViewModel
{
	public int UserTaskId { get; set; }

	public string UserTaskTime { get; set; }

	public string UserTaskDatePersian { get; set; }

	public string UserTaskDate { get; set; }

	public string DayName { get; set; }

	public string DayNamePersian { get; set; }

	public string PriorityColor { get; set; }

	public int? UserId { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }
}
