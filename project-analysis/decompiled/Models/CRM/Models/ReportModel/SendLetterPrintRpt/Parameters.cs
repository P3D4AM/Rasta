using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.SendLetterPrintRpt;

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

	public SecspRpt_PrintSendLetter_Result PrintSendLetter { get; set; }

	public byte[] SignatureFirstUser { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureVerifierRequestUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }

	public List<CRMspDyPrintCmpForm_Result> ListDyPrintCmpForm { get; set; }

	public List<CRMspDyPrintPrsForm_Result> ListDyPrintPrsForm { get; set; }

	public List<CRMspDyPrintPrjForm_Result> ListDyPrintPrjForm { get; set; }

	public List<CRMspDyPrintSecLetterForm_Result> ListDyPrintLetterForm { get; set; }

	public List<CRMspPrintProjectInformationTree_Result> ListPrintProjectInformationTree { get; set; }

	public List<WSspRpt_PrintVerificationRequestDetails_Result> NotUsed_ListPrintLetterVerificationRequestDetails { get; set; }
}
