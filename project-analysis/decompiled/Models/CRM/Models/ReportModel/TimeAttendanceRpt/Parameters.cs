using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.TimeAttendanceRpt;

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

	public List<CRMspRpt_TimeAttendance_Result> TimeAttendances { get; set; }

	public List<CRMspRpt_TimeAttendanceFooter_Result> Footer { get; set; }
}
