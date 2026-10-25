using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintOrderIndicatorFilterRpt;

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

	public List<mct_WSspSelectOrderIndicatorWithItems_Result> NotUsed_ListOrderIndicatorWithItems { get; set; }

	public string LogoLeft { get; set; }

	public string LogoRight { get; set; }

	public List<mct_WSspSelectOrderIndicatorSum_Result> NotUsed_ListOrderIndicatorFooter { get; set; }

	public List<WSspSelectOrderIndicatorWithItemsSerial_Result> NotUsed_ListOrderIndicatorWithItemsSerial { get; set; }

	public List<OrdLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<CRMspSelectCompanyMoneyBagByCmpIds_Result> NotUsed_ListCompanyMoneyBag { get; set; }

	public List<WSspSelectProductSpecificationValues_Result> NotUsed_ListOrderItemSpecifications { get; set; }

	public List<WSspSelectOrderPaymentsByOrdIds_Result> NotUsed_ListOrderPayments { get; set; }

	public List<WSspSelectBuyOrderByReqCmp_Result> NotUsed_ListBuyOrderByReqCmp { get; set; }

	public List<WSspSelectBuyOrderByFacilityCmp_Result> NotUsed_ListBuyOrderByFacilityCmp { get; set; }

	public List<WSspSelectDocByOrdId_Result> NotUsed_ListDoc { get; set; }
}
