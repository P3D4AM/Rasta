using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.TimeAttendanceCartableRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public string ReportFDate { get; set; }

	public string ReportTDate { get; set; }

	public int YearNum { get; set; }

	public int MonthNum { get; set; }

	public string MonthName { get; set; }

	public List<CRMResultsTimeAttendanceCartableViewModel> TimeAttendances { get; set; }

	public TimeAttendanceCartableRptFooter Footer { get; set; }
}
