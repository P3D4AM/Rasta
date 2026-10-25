using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectInformationsMetadata))]
public class CrmProjectInformations
{
	public int ProjectInformationId { get; set; }

	public int ProjectId { get; set; }

	public int FieldTitleId { get; set; }

	public string FieldValue { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual CrmProjectFieldTitle CrmProjectFieldTitle { get; set; }

	public virtual ICollection<CrmProjectInformations_Lang> CrmProjectInformations_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmProjectInformations()
	{
		CrmProjectInformations_Lang = (ICollection<CrmProjectInformations_Lang>)new HashSet<CrmProjectInformations_Lang>();
	}
}
