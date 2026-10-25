using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectFieldTitleMetadata))]
public class CrmProjectFieldTitle
{
	public int ProjectFieldTitleId { get; set; }

	public int? ProjectId { get; set; }

	public string FieldTitle { get; set; }

	public bool? IsDefualtField { get; set; }

	public int ValueType { get; set; }

	public int? SortCode { get; set; }

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

	public virtual ICollection<CrmProjectDefualtValue> CrmProjectDefualtValue { get; set; }

	public virtual ICollection<CrmProjectFieldTitle_Lang> CrmProjectFieldTitle_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmProjectInformations> CrmProjectInformations { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmProjectFieldTitle()
	{
		CrmProjectDefualtValue = (ICollection<CrmProjectDefualtValue>)new HashSet<CrmProjectDefualtValue>();
		CrmProjectFieldTitle_Lang = (ICollection<CrmProjectFieldTitle_Lang>)new HashSet<CrmProjectFieldTitle_Lang>();
		CrmProjectInformations = (ICollection<CrmProjectInformations>)new HashSet<CrmProjectInformations>();
	}
}
