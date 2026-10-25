using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintDyFormsReportRpt;

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

	public List<CRMspDyFormsReportViewModel> NotUsed_ListFormReport { get; set; }

	public List<FieldValueItemViewModel> NotUsed_ListFieldValue { get; set; }

	public List<CRMspDySelectCompanyProjectByMasterValueId_Result> NotUsed_ListProject { get; set; }

	public List<CRMspDySelectPreOrderByMasterValueId_Result> NotUsed_ListPreOrder { get; set; }

	public List<CRMspDySelectOrderByMasterValueId_Result> NotUsed_ListOrder { get; set; }

	public List<CRMspDySelectDocByMasterValueId_Result> NotUsed_ListDoc { get; set; }
}
