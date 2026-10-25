using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.CmpOrdStockPayAccPrintRpt;

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

	public List<WSspRpt_CmpOrdStockPayAccI_Result> NotUsed_ListWSspRpt_CmpOrdStockPayAccI { get; set; }

	public List<WSspRpt_CmpOrdStockPayAccII_Result> NotUsed_ListWSspRpt_CmpOrdStockPayAccII { get; set; }

	public List<WSspRpt_CmpOrdStockPayAccIII_Result> NotUsed_ListWSspRpt_CmpOrdStockPayAccIII { get; set; }

	public WSspRpt_CmpOrdStockPayAccIV_Result CmpOrdStockPayAccIV { get; set; }
}
