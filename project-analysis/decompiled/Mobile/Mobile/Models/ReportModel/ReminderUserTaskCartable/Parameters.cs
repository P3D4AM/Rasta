using System;
using System.Collections.Generic;

namespace Mobile.Models.ReportModel.ReminderUserTaskCartable;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public List<CRMspLoadUserTasksWeb_Result> NotUsed_ListReminderUserTasks { get; set; }
}
