using System;

namespace CRM.Models;

public class CrmVersionUpgradeDetailsMetadata
{
	public int ID { get; set; }

	public string Version { get; set; }

	public string ActionName { get; set; }

	public bool Succeed { get; set; }

	public string ActionValue { get; set; }

	public string RunDatePersian { get; set; }

	public DateTime? RunDate { get; set; }

	public int? RunUserId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
