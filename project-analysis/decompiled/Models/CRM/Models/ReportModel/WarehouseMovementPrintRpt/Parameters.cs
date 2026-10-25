using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.WarehouseMovementPrintRpt;

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

	public WSspRpt_PrintDoc_Result PrintDoc { get; set; }

	public List<WSspRpt_PrintDocItems_Result> NotUsed_ListPrintDocItems { get; set; }

	public List<WSspRpt_PrintDocItemSerials_Result> NotUsed_ListPrintDocItemSerials { get; set; }

	public List<CRMspDyPrintCmpForm_Result> ListDyPrintCmpForm { get; set; }

	public List<CRMspDyPrintPrsForm_Result> ListDyPrintPrsForm { get; set; }

	public List<CRMspDyPrintPrjForm_Result> ListDyPrintPrjForm { get; set; }

	public List<CRMspDyPrintDocForm_Result> ListDyPrintDocForm { get; set; }

	public List<CRMspPrintProjectInformationTree_Result> ListPrintProjectInformationTree { get; set; }

	public List<WSspRpt_PrintDocVerificationRequestDetails_Result> NotUsed_ListPrintDocVerificationRequestDetails { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureFirstRegisterUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }

	public List<WSspRpt_PrintDocItemPrdPicture_Result> NotUsed_ListDocItemPrdPicture { get; set; }

	public List<WSspRpt_PrintDocItemsFromQuantity_Result> NotUsed_ListPrintDocItemsFromQuantity { get; set; }

	public List<DocLinkAccDataViewModel> NotUsed_ListLinkAccData { get; set; }

	public List<WSspRpt_PrintDocOrder_Result> NotUsed_ListOrder { get; set; }
}
