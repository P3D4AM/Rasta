using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.CmpInfoFilterDataRpt;

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

	public List<mct_CRMspRpt_CompanyFilterData_Result> NotUsed_ListCompanyInfo { get; set; }

	public List<CRMspSelectCompanyLogoByCmpIds_Result> NotUsed_ListCompanyLogo { get; set; }

	public List<CrmspRpt_CompanyPersonInfo_Result> NotUsed_ListCompanyPersonInfo { get; set; }
}
