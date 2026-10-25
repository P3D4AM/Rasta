using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.HourlyMissionPrintRpt;

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

	public CRMspRpt_PrintLeave_Result PrintLeave { get; set; }

	public List<WSspRpt_PrintVerificationRequestDetails_Result> NotUsed_ListPrintLeaveVerificationRequestDetails { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureFirstRegisterUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }
}
