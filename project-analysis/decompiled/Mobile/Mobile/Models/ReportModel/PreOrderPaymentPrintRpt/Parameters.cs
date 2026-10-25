using System;

namespace Mobile.Models.ReportModel.PreOrderPaymentPrintRpt;

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

	public WSspRpt_PrintPreOrderPaymentById_Result PreOrderPayment { get; set; }

	public byte[] SignatureFirstUser { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }
}
