using System;

namespace CRMIdealApi.ApiModels;

public class ReminderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public DateTime ApiUserTaskDate { get; set; }

	public string ApiUserTaskTime { get; set; }

	public string ApiUserTaskTitle { get; set; }

	public string ApiUserTaskDescription { get; set; }

	public string ApiUserTaskRemindTime { get; set; }

	public int? ApiUserTaskPriorityId { get; set; }

	public int? ApiUserTaskGroupId { get; set; }

	public int? ApiUserTaskShowAllarm { get; set; }

	public bool? ApiUserTaskDidIt { get; set; }

	public DateTime? ApiUserTaskRemindDateTime { get; set; }

	public bool? ApiUserTaskIsPublic { get; set; }

	public string ApiUserTaskTimeEnd { get; set; }

	public int? ApiObjectTypeId { get; set; }

	public int? ApiObjectId { get; set; }

	public bool? ApiUserTaskNoTimeOverlap { get; set; }

	public string ApiUserTaskCompanyIds { get; set; }

	public bool? ApiUserTaskRepeatDaily { get; set; }

	public bool? ApiUserTaskRepeatWeekly { get; set; }

	public bool? ApiUserTaskRepeatMonthly { get; set; }

	public bool? ApiUserTaskRepeatYearly { get; set; }

	public bool? ApiUserTaskRemindRepeatDaily { get; set; }

	public bool? ApiUserTaskRemindRepeatWeekly { get; set; }

	public bool? ApiUserTaskRemindRepeatMonthly { get; set; }

	public bool? ApiUserTaskRemindRepeatYearly { get; set; }

	public int? LanguageId { get; set; }
}
