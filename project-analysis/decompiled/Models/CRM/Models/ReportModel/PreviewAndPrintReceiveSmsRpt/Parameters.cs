using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PreviewAndPrintReceiveSmsRpt;

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

	public DateTime FromDate { get; set; }

	public DateTime ToDate { get; set; }

	public string FromDateFa { get; set; }

	public string ToDateFa { get; set; }

	public string FromNumber { get; set; }

	public List<CRMspSmsSelectReceiveSMS_Result> NotUsed_ListSmsSelectReceiveSMS { get; set; }
}
