using System;

namespace CRM.Models.ReportModel.PrintSurveyWithCompanyValuesRpt;

public class Parameters
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public SurveyViewModelObj SurveyObj { get; set; }
}
