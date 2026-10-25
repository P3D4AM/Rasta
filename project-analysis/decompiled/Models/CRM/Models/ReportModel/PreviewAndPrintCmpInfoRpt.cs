using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel;

public class PreviewAndPrintCmpInfoRpt
{
	public string ReporterUserName { get; set; }

	public DateTime ReportDateTime { get; set; }

	public string ReportDay { get; set; }

	public string CoLogo { get; set; }

	public string Parameter1 { get; set; }

	public string Parameter2 { get; set; }

	public string Parameter3 { get; set; }

	public CrmsysSettingRpt SysSetting { get; set; }

	public CrmspRpt_CompanyInfo_Result CompanyInfo { get; set; }

	public List<CrmspRpt_CompanyPersonInfo_Result> ListCompanyPersonInfo { get; set; }

	public List<CrmspRpt_CompanyProjectInfo_Result> ListCompanyProjectInfo { get; set; }

	public List<CrmspRpt_CompanyConversationInfo_Result> ListCompanyConversationInfo { get; set; }

	public List<CRMspDyPrintCmpForm_Result> ListDyPrintCmpForm { get; set; }

	public List<CRMspDyPrintPrsForm_Result> ListDyPrintPrsForm { get; set; }

	public List<CRMspDyPrintPrjForm_Result> ListDyPrintPrjForm { get; set; }

	public List<CRMspDyPrintCnvsForm_Result> ListDyPrintCnvsForm { get; set; }

	public List<CRMspPrintProjectInformationTree_Result> ListPrintProjectInformationTree { get; set; }
}
