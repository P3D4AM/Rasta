using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmUserTaskGroupsMetadata))]
public class CrmUserTaskGroups
{
	public int UserTaskGroupId { get; set; }

	public string UserTaskGroup { get; set; }

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

	public virtual ICollection<CrmUserTaskGroups_Lang> CrmUserTaskGroups_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmUserTasks> CrmUserTasks { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmUserTaskGroups()
	{
		CrmUserTaskGroups_Lang = (ICollection<CrmUserTaskGroups_Lang>)new HashSet<CrmUserTaskGroups_Lang>();
		CrmUserTasks = (ICollection<CrmUserTasks>)new HashSet<CrmUserTasks>();
	}
}
