using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectGroupsMultiMetadata))]
public class CrmProjectGroupsMulti
{
	public int ProjectGroupsMultiId { get; set; }

	public string ProjectGroupsMultiName { get; set; }

	public string ProjectGroupsMultiDesc { get; set; }

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

	public virtual ICollection<CrmProjectGroupsMulti_Lang> CrmProjectGroupsMulti_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmProjectMultiGroups> CrmProjectMultiGroups { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmProjectGroupsMulti()
	{
		CrmProjectGroupsMulti_Lang = (ICollection<CrmProjectGroupsMulti_Lang>)new HashSet<CrmProjectGroupsMulti_Lang>();
		CrmProjectMultiGroups = (ICollection<CrmProjectMultiGroups>)new HashSet<CrmProjectMultiGroups>();
	}
}
