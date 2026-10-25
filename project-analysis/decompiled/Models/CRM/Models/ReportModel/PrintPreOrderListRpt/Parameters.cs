using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintPreOrderListRpt;

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

	public List<mct_WSspSelectPreOrderListRpt_Result> NotUsed_ListPreOrderList { get; set; }

	public List<PordLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<WSspSelectProductSpecificationValues_Result> NotUsed_ListPreOrderItemSpecifications { get; set; }

	public List<WSspSelectPreOrderPaymentsByPordIds_Result> NotUsed_ListPreOrderPayments { get; set; }

	public List<WSspSelectOrderByPordId_Result> NotUsed_ListOrders { get; set; }

	public List<WSspSelectDocByPordId_Result> NotUsed_ListDocs { get; set; }

	public List<WSspSelectStockSupplyByPordId_Result> NotUsed_ListStockSupply { get; set; }
}
