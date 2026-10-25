using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintPayRollListRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public PayRollspPrintList_Result PayRollList { get; set; }

	public List<PayRollspPrintListItems_Result> NotUsed_PayRollListItems { get; set; }

	public List<PayRollspPrintUserCycleItemValuesWithListId_Result> NotUsed_ListUserCycleItemValues { get; set; }

	public List<PayRollspPrintUserPaymentsWithListId_Result> NotUsed_ListUserPayments { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public List<PayRollspPrintUserCycleOrderCommissionsWithListId_Result> NotUsed_ListOrderCommissions { get; set; }
}
