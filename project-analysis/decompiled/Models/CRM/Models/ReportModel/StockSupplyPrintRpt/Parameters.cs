using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.StockSupplyPrintRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public List<WSspRpt_PrintStockSupply_Result> ListStockSupply { get; set; }

	public List<WSspReturnBuyOrderFromStockSupply_Result> ListBuyOrder { get; set; }

	public List<CRMspDyPrintCmpForm_Result> ListDyPrintCmpForm { get; set; }

	public List<CRMspDyPrintPrsForm_Result> ListDyPrintPrsForm { get; set; }

	public List<CRMspDyPrintPrjForm_Result> ListDyPrintPrjForm { get; set; }

	public List<CRMspDyPrintStsupForm_Result> ListDyPrintStsupForm { get; set; }

	public List<CRMspPrintProjectInformationTree_Result> ListPrintProjectInformationTree { get; set; }

	public List<WSspRpt_PrintVerificationRequestDetails_Result> NotUsed_ListPrintStockSupplyVerificationRequestDetails { get; set; }

	public List<WSspRpt_PrintStockSupplyItemPrdPicture_Result> NotUsed_ListStockSupplyItemPrdPicture { get; set; }

	public byte[] SignatureFirstUser { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureReferUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }
}
