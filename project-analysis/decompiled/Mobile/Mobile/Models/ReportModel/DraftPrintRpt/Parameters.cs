using System;
using System.Collections.Generic;

namespace Mobile.Models.ReportModel.DraftPrintRpt;

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

	public WSspRpt_PrintDoc_Result PrintDraft { get; set; }

	public List<WSspRpt_PrintDocItems_Result> NotUsed_ListDraftItems { get; set; }

	public List<WSspRpt_PrintDocItemSerials_Result> NotUsed_ListDraftItemSerials { get; set; }

	public List<CRMspDyPrintCmpForm_Result> ListDyPrintCmpForm { get; set; }

	public List<CRMspDyPrintPrsForm_Result> ListDyPrintPrsForm { get; set; }

	public List<CRMspDyPrintPrjForm_Result> ListDyPrintPrjForm { get; set; }

	public List<CRMspDyPrintDocForm_Result> ListDyPrintDocForm { get; set; }

	public List<CRMspPrintProjectInformationTree_Result> ListPrintProjectInformationTree { get; set; }

	public List<WSspRpt_PrintVerificationRequestDetails_Result> NotUsed_ListPrintOrderVerificationRequestDetails { get; set; }

	public List<WSspRpt_PrintDocVerificationRequestDetails_Result> NotUsed_ListPrintDocVerificationRequestDetails { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureFirstRegisterUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }

	public List<WSspRpt_PrintDocItemPrdPicture_Result> NotUsed_ListDraftItemPrdPicture { get; set; }

	public List<WSspRpt_PrintDocItemsFromQuantity_Result> NotUsed_ListDraftItemsFromQuantity { get; set; }

	public List<DocLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<CmpAccountingLinkAccDataViewModel> NotUsed_ListCmpAllPayRemainLinkAccData { get; set; }

	public decimal? CmpLinkAccAllPayRemain { get; set; }
}
