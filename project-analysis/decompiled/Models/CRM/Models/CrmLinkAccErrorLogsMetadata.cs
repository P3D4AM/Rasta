using System;

namespace CRM.Models;

public class CrmLinkAccErrorLogsMetadata
{
	public int LinkAccErrorLogId { get; set; }

	public string ScriptName { get; set; }

	public string PartTitle { get; set; }

	public string ErrorMessage { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }
}
