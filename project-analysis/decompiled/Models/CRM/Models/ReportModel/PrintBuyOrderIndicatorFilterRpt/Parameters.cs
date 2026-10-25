using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintBuyOrderIndicatorFilterRpt;

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

	public List<WSspSelectBuyOrderIndicatorWithItems_Result> NotUsed_ListBuyOrderIndicatorWithItems { get; set; }

	public List<mct_WSspSelectBuyOrderIndicatorSum_Result> NotUsed_ListBuyOrderIndicatorFooter { get; set; }

	public List<WSspSelectBuyOrderIndicatorWithItemsSerial_Result> NotUsed_ListBuyOrderIndicatorWithItemsSerial { get; set; }

	public List<BordLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<WSspSelectProductSpecificationValues_Result> NotUsed_ListBuyOrderItemSpecifications { get; set; }
}
