using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintPayRollUserCycleRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public PayRollspPrintUserCycle_Result PayRollspPrintUserCycle { get; set; }

	public List<PayRollspPrintUserCycleItemValues_Result> NotUsed_ListUserCycleItems { get; set; }

	public List<PayRollspPrintUserPayments_Result> NotUsed_ListUserPayments { get; set; }

	public byte[] SignatureFirstUser { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }

	public byte[] SignatureCrmUser { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public List<PayRollspPrintUserCycleOrderCommissions_Result> NotUsed_ListOrderCommissions { get; set; }

	public List<PayRollspPrintUserCycleItemValuesInfo_Result> NotUsed_ListUserCycleItemsInfo { get; set; }
}
