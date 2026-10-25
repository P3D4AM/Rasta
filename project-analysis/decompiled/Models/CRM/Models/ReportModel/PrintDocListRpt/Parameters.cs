using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintDocListRpt;

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

	public List<mct_WSspDocIndicator_Mode2_Result> NotUsed_ListDocList { get; set; }

	public List<DocLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<WSspDocIndicatorSelectOrder_Result> NotUsed_ListOrder { get; set; }

	public List<WSspSelectPreOrderByDocId_Result> NotUsed_ListPreOrder { get; set; }

	public List<DocListLinkAccData> NotUsed_ListProductLinkAccData { get; set; }
}
