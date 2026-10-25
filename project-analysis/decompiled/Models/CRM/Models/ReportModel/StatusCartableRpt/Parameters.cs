using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.StatusCartableRpt;

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

	public List<CRMspResultsStatusCartable_Result> NotUsed_ListCompanyInfo { get; set; }
}
