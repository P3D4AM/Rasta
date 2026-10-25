using System;
using System.Collections.Generic;

namespace Mobile.Models.ReportModel.OrderPrintRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public List<WSspRpt_PrintOrder_Result> NotUsed_ListPrintOrder { get; set; }

	public List<WSspRpt_PrintOrderItemSerials_Result> NotUsed_ListPrintOrderItemSerials { get; set; }

	public List<WSspRpt_PrintOrderItems_Result> NotUsed_ListPrintOrderItems { get; set; }

	public List<WSspRpt_PrintOrderPayments_Result> NotUsed_ListPrintOrderPayments { get; set; }

	public string Signature { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public CRMspReturnCmpAccountingSummary_Result CmpAccountingSummary { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureReferUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }

	public List<CRMspDyPrintCmpForm_Result> ListDyPrintCmpForm { get; set; }

	public List<CRMspDyPrintPrsForm_Result> ListDyPrintPrsForm { get; set; }

	public List<CRMspDyPrintPrjForm_Result> ListDyPrintPrjForm { get; set; }

	public List<CRMspDyPrintPordForm_Result> ListDyPrintPordForm { get; set; }

	public List<CRMspDyPrintOrdForm_Result> ListDyPrintOrdForm { get; set; }

	public List<CRMspPrintProjectInformationTree_Result> ListPrintProjectInformationTree { get; set; }

	public List<WSspRpt_PrintOrderDoc_Result> NotUsed_ListPrintOrderDoc { get; set; }

	public List<WSspRpt_PrintVerificationRequestDetails_Result> NotUsed_ListPrintOrderVerificationRequestDetails { get; set; }

	public decimal? CmpLinkAccAllPayRemain { get; set; }

	public List<WSspRpt_PrintOrderItemPrdPicture_Result> NotUsed_ListOrderItemPrdPicture { get; set; }

	public double SumScores { get; set; }

	public double SumUsableScores { get; set; }

	public List<ScorespSelectOrderScores_Result> NotUsed_ScorespSelectOrderScores { get; set; }

	public List<OrdLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<PayLinkAccDataViewModel> NotUsed_ListPayLinkAccData { get; set; }

	public List<CmpAccountingLinkAccDataViewModel> NotUsed_ListCmpAllPayRemainLinkAccData { get; set; }
}
