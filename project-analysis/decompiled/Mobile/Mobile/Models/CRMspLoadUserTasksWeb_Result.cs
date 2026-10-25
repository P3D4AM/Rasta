using System;

namespace Mobile.Models;

public class CRMspLoadUserTasksWeb_Result
{
	public int UserTaskId { get; set; }

	public string UserTaskDatePersian { get; set; }

	public DateTime? UserTaskDate { get; set; }

	public string UserTaskTime { get; set; }

	public int? UserTaskTimeHour { get; set; }

	public int? UserTaskTimeMinute { get; set; }

	public string UserTaskTitle { get; set; }

	public string UserTaskDescription { get; set; }

	public int? UserTaskPriorityId { get; set; }

	public string UserTaskPriority { get; set; }

	public int? UserTaskGroupId { get; set; }

	public string UserTaskGroup { get; set; }

	public int? UserTaskShowAllarm { get; set; }

	public bool? UserTaskDidIt { get; set; }

	public DateTime? UserTaskDidItDate { get; set; }

	public string UserTaskDidItDatePersian { get; set; }

	public string WeekdayName { get; set; }

	public string UserTaskCalendarDate { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string UserTaskRemindDate { get; set; }

	public string UserTaskRemindTime { get; set; }

	public DateTime? UserTaskRemindDateTime { get; set; }

	public bool? UserTaskIsPublic { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string UserTaskTimeEnd { get; set; }

	public int? WeekdayNum { get; set; }

	public int? UserTaskTimeEndHour { get; set; }

	public int? UserTaskTimeEndMinute { get; set; }

	public int? ObjectTypeId { get; set; }

	public int? ObjectId { get; set; }

	public string Object { get; set; }

	public string UserTaskCompanyIds { get; set; }

	public string UserTaskCompanys { get; set; }

	public bool? UserTaskRepeatDaily { get; set; }

	public bool? UserTaskRepeatWeekly { get; set; }

	public bool? UserTaskRepeatMonthly { get; set; }

	public bool? UserTaskRepeatYearly { get; set; }

	public bool? UserTaskNoTimeOverlap { get; set; }

	public bool? UserTaskRemindRepeatDaily { get; set; }

	public bool? UserTaskRemindRepeatWeekly { get; set; }

	public bool? UserTaskRemindRepeatMonthly { get; set; }

	public bool? UserTaskRemindRepeatYearly { get; set; }

	public string EditUser { get; set; }

	public string TaskPriorityColor { get; set; }

	public int Type { get; set; }

	public string UserTaskLinkIdStr { get; set; }

	public DateTime? UserTaskDateEnd { get; set; }

	public string UserTaskDateEndPersian { get; set; }

	public string UserTaskDidItInfoJson { get; set; }

	public bool? UserTaskDidItInPeriod { get; set; }

	public string UserTaskDidItTimeInPeriod { get; set; }
}
