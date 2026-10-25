using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmUserTaskPrioritiesMetadata))]
public class CrmUserTaskPriorities
{
	public int UserTaskPriorityId { get; set; }

	public string Priority { get; set; }

	public string Color { get; set; }

	public string PriorityDesc { get; set; }

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

	public virtual ICollection<CrmUserTaskPriorities_Lang> CrmUserTaskPriorities_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmUserTasks> CrmUserTasks { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmUserTaskPriorities()
	{
		CrmUserTaskPriorities_Lang = (ICollection<CrmUserTaskPriorities_Lang>)new HashSet<CrmUserTaskPriorities_Lang>();
		CrmUserTasks = (ICollection<CrmUserTasks>)new HashSet<CrmUserTasks>();
	}
}
