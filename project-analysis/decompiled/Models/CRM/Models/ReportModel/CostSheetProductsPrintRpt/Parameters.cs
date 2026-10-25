using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.CostSheetProductsPrintRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public List<WSspSelectCostSheetProducts_Result> ListProducts { get; set; }
}
