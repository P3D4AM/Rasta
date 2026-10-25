using System;
using System.Collections.Generic;
using CRM.Models.ReportModel;

namespace CRM.Models;

public class DyFormChartPrint
{
	public CrmsysSettingRpt SysSetting { get; set; }

	public List<DyFormChartPrintForms> NotUsed_Forms { get; set; }

	public List<DyFormChartPrintFormFields> NotUsed_FormFields { get; set; }

	public List<DyFormChartPrintFormFieldItems> NotUsed_FormFieldItems { get; set; }

	public List<DyFormChartPrintFormFieldValues> NotUsed_FormFieldValues { get; set; }

	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public string Signature { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public byte[] SignatureLastEditUser { get; set; }

	public byte[] SignatureReferUser { get; set; }

	public byte[] SignatureVerifierUser { get; set; }
}
