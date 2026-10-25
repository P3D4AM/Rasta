using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.CommissionCartableRpt;

public class Parameters
{
	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public List<WSspSelectUserOrderCommissionsViewModel> NotUsed_ListUserOrderCommissions { get; set; }
}
