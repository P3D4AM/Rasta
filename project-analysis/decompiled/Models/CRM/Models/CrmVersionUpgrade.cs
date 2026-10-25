using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmVersionUpgradeMetadata))]
public class CrmVersionUpgrade
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

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }
}
