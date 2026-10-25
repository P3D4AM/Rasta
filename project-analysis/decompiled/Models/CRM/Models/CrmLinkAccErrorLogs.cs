using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkAccErrorLogsMetadata))]
public class CrmLinkAccErrorLogs
{
	public int LinkAccErrorLogId { get; set; }

	public string ScriptName { get; set; }

	public string PartTitle { get; set; }

	public string ErrorMessage { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public virtual Users Users { get; set; }
}
