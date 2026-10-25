using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.CmpOrderAccPrintRpt;

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

	public List<WSspRpt_CmpOrderAcc_Result> NotUsed_ListWSspRpt_CmpOrderAcc { get; set; }

	public decimal? SumOrdTotalAmount { get; set; }

	public decimal? SumRemainOrdAmount { get; set; }

	public decimal? SumPayAmount { get; set; }
}
