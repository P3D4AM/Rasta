using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel;

public class SampleRpt
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public CrmspRpt_CompanyInfo_Result CompanyInfo { get; set; }

	public List<CrmspRpt_CompanyPersonInfo_Result> ListCompanyPersonInfo { get; set; }
}
