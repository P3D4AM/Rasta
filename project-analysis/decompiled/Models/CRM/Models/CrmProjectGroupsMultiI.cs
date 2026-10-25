using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectGroupsMultiIMetadata))]
public class CrmProjectGroupsMultiI
{
	public int ProjectGroupsMultiIId { get; set; }

	public string ProjectGroupsMultiIName { get; set; }

	public string ProjectGroupsMultiIDesc { get; set; }

	public bool? IsDefualtField { get; set; }

	public int? SortCode { get; set; }

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

	public virtual ICollection<CrmProjectGroupsMultiI_Lang> CrmProjectGroupsMultiI_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmProjectMultiIGroups> CrmProjectMultiIGroups { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmProjectGroupsMultiI()
	{
		CrmProjectGroupsMultiI_Lang = (ICollection<CrmProjectGroupsMultiI_Lang>)new HashSet<CrmProjectGroupsMultiI_Lang>();
		CrmProjectMultiIGroups = (ICollection<CrmProjectMultiIGroups>)new HashSet<CrmProjectMultiIGroups>();
	}
}
