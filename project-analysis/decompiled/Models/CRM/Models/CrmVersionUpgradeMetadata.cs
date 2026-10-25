using System;

namespace CRM.Models;

public class CrmVersionUpgradeMetadata
{
	public int ID { get; set; }

	public string Version { get; set; }

	public string ReleaseDatePersian { get; set; }

	public DateTime ReleaseDate { get; set; }

	public bool? Upgraded { get; set; }

	public string UpgradedDatePersian { get; set; }

	public DateTime? UpgradedDate { get; set; }

	public int? UpgradedUserID { get; set; }

	public Guid? guId { get; set; }

	public string AppType { get; set; }
}
