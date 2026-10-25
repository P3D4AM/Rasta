using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.PrintCompanyProjectWithFilterDataRptForParsService;

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

	public List<CRMspRpt_CompanyProjectWithFilterDataForParsService_Result> NotUsed_ListProjects { get; set; }

	public List<CRMspRpt_CompanyProjectWithFilterDataForParsServiceGasCooler_Result> NotUsed_ListProjectsGasCooler { get; set; }

	public List<CRMspRpt_CompanyProjectWithFilterDataForParsServiceLaundryDishwasher_Result> NotUsed_ListProjectsLaundryDishwasher { get; set; }
}
