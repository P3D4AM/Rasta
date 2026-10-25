using System;
using System.Collections.Generic;

namespace Mobile.Models.ReportModel.BuyOrderPrintRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public List<WSspRpt_PrintBuyOrder_Result> NotUsed_ListBuyOrder { get; set; }

	public List<WSspRpt_PrintBuyOrderItemSerials_Result> NotUsed_ListBuyOrderItemSerials { get; set; }

	public List<WSspRpt_PrintBuyOrderItems_Result> NotUsed_ListPrintBuyOrderItems { get; set; }

	public List<WSspRpt_PrintBuyOrderPayments_Result> NotUsed_ListPrintBuyOrderPayments { get; set; }

	public string Signature { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public List<CRMspDyPrintCmpForm_Result> ListDyPrintCmpForm { get; set; }

	public List<CRMspDyPrintPrsForm_Result> ListDyPrintPrsForm { get; set; }

	public List<CRMspDyPrintPrjForm_Result> ListDyPrintPrjForm { get; set; }

	public List<CRMspDyPrintBordForm_Result> ListDyPrintBordForm { get; set; }

	public List<CRMspPrintProjectInformationTree_Result> ListPrintProjectInformationTree { get; set; }

	public List<WSspRpt_PrintVerificationRequestDetails_Result> NotUsed_ListPrintBuyOrderVerificationRequestDetails { get; set; }

	public byte[] SignatureFirstUser { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureReferUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }

	public List<BordLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<PayLinkAccDataViewModel> NotUsed_ListPayLinkAccData { get; set; }

	public bool? ActNotShowFinancialInfo { get; set; }
}
