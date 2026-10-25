using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintProjectInformationTreeRpt;

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

	public List<CRMspRpt_ProjectInformationTree_Result> ListProjectInformationTreeInfo { get; set; }

	public CRMspRpt_ProjectGroupsMulti_Result ProjectGroupsMultiInfo { get; set; }
}
