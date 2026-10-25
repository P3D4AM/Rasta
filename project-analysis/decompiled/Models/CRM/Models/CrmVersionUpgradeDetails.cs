using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmVersionUpgradeDetailsMetadata))]
public class CrmVersionUpgradeDetails
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

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }
}
