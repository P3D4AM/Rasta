using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmUserTasksMetadata))]
public class CrmUserTasks
{
	public int UserTaskId { get; set; }

	public string UserTaskDatePersian { get; set; }

	public DateTime UserTaskDate { get; set; }

	public string UserTaskTime { get; set; }

	public string UserTaskTitle { get; set; }

	public string UserTaskDescription { get; set; }

	public int? UserTaskPriorityId { get; set; }

	public int? UserTaskGroupId { get; set; }

	public int? UserTaskShowAllarm { get; set; }

	public bool? UserTaskDidIt { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string UserTaskRemindDate { get; set; }

	public string UserTaskRemindTime { get; set; }

	public DateTime? UserTaskRemindDateTime { get; set; }

	public bool? UserTaskIsPublic { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string UserTaskTimeEnd { get; set; }

	public int? ObjectTypeId { get; set; }

	public int? ObjectId { get; set; }

	public bool? UserTaskNoTimeOverlap { get; set; }

	public string UserTaskCompanyIds { get; set; }

	public bool? UserTaskRepeatDaily { get; set; }

	public bool? UserTaskRepeatWeekly { get; set; }

	public bool? UserTaskRepeatMonthly { get; set; }

	public bool? UserTaskRepeatYearly { get; set; }

	public bool? UserTaskRemindRepeatDaily { get; set; }

	public bool? UserTaskRemindRepeatWeekly { get; set; }

	public bool? UserTaskRemindRepeatMonthly { get; set; }

	public bool? UserTaskRemindRepeatYearly { get; set; }

	public string UserTaskLinkIdStr { get; set; }

	public DateTime? UserTaskDateEnd { get; set; }

	public string UserTaskDateEndPersian { get; set; }

	public int? UserTaskCId { get; set; }

	public DateTime? UserTaskDidItDate { get; set; }

	public string UserTaskDidItDatePersian { get; set; }

	public string UserTaskDidItInfoJson { get; set; }

	public virtual CrmUserTaskGroups CrmUserTaskGroups { get; set; }

	public virtual CrmUserTaskPriorities CrmUserTaskPriorities { get; set; }

	public virtual ICollection<CrmUserTasks_Lang> CrmUserTasks_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmUserTasks()
	{
		CrmUserTasks_Lang = (ICollection<CrmUserTasks_Lang>)new HashSet<CrmUserTasks_Lang>();
	}
}
