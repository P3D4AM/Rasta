using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PreOrderPrintRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public List<WSspRpt_PrintPreOrder_Result> ListPrintPreOrder { get; set; }

	public List<WSspSelectPreOrderItemSpecificationByItemId_Result> ListPrintPreOrderItemSpecification { get; set; }

	public List<WSspRpt_PrintPreOrderPayments_Result> ListPrintPreOrderPayments { get; set; }

	public byte[] SignatureFirstUser { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureReferUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public List<CRMspDyPrintCmpForm_Result> ListDyPrintCmpForm { get; set; }

	public List<CRMspDyPrintPrsForm_Result> ListDyPrintPrsForm { get; set; }

	public List<CRMspDyPrintPrjForm_Result> ListDyPrintPrjForm { get; set; }

	public List<CRMspDyPrintPordForm_Result> ListDyPrintPordForm { get; set; }

	public List<CRMspPrintProjectInformationTree_Result> ListPrintProjectInformationTree { get; set; }

	public List<WSspRpt_PrintVerificationRequestDetails_Result> NotUsed_ListPrintPreOrderOrderVerificationRequestDetails { get; set; }

	public decimal? CmpLinkAccAllPayRemain { get; set; }

	public bool? ActNotShowFinancialInfo { get; set; }

	public List<WSspRpt_PrintPreOrderItemPrdPicture_Result> NotUsed_ListPreOrderItemPrdPicture { get; set; }

	public WSspRpt_PrintPreOrderById_Result PrintPreOrder { get; set; }

	public List<WSspRpt_PrintPreOrderDiscounts_Result> NotUsed_ListPreOrderDiscount { get; set; }

	public List<PordLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<PayLinkAccDataViewModel> NotUsed_ListPayLinkAccData { get; set; }

	public List<CmpAccountingLinkAccDataViewModel> NotUsed_ListCmpAllPayRemainLinkAccData { get; set; }

	public List<WSspSelectProductSpecificationValues_Result> NotUsed_ListPreOrderItemSpecifications { get; set; }

	public CRMspReturnCmpAccountingSummary_Result CmpAccountingSummary { get; set; }
}
