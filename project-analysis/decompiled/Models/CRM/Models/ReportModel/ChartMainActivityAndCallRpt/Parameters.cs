using System;
using System.Collections.Generic;

namespace CRM.Models.ReportModel.ChartMainActivityAndCallRpt;

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

	public List<CRMspRpt_ChartMainActivityAndCall_Result> NotUsed_ListChartMainActivityAndCall { get; set; }

	public List<CRMspRpt_ChartActivityAndCallAllCmpUserInMonthInfoWeb_Result> NotUsed_ListAllCmpUserInMonthInfo { get; set; }

	public List<CRMspRpt_ChartActivityAndCallAllCmpInMonthWeb_Result> NotUsed_ListAllCmpInMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallAllUserCmpInMonthWeb_Result> NotUsed_ListAllUserCmpInMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallCmpInProvinceWeb_Result> NotUsed_ListCmpInProvince { get; set; }

	public List<CRMspRpt_ChartActivityAndCallCmpUser_Result> NotUsed_ListCmpUser { get; set; }

	public List<CRMspRpt_ChartActivityAndCallCntInLine_Result> NotUsed_ListCallCntInLine { get; set; }

	public List<CRMspRpt_ChartActivityAndCallCntInLineMonth_Result> NotUsed_ListCallCntInLineMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallCntInMonth_Result> NotUsed_ListCallCntInMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallFromComp_Result> NotUsed_ListCallFromComp { get; set; }

	public List<CRMspRpt_ChartActivityAndCallInCallCntInLine_Result> NotUsed_ListInCallCntInLine { get; set; }

	public List<CRMspRpt_ChartActivityAndCallInCallCntInLineInMonth_Result> NotUsed_ListCallCntInLineInMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallInNotRegCall_Result> NotUsed_ListInNotRegCall { get; set; }

	public List<CRMspRpt_ChartActivityAndCallInNotRegCallInMonth_Result> NotUsed_ListInNotRegCallInMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallInRegCall_Result> NotUsed_ListInRegCall { get; set; }

	public List<CRMspRpt_ChartActivityAndCallInRegCallInMonth_Result> NotUsed_ListInRegCallInMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallOutCallCntInLine_Result> NotUsed_ListOutCallCntInLine { get; set; }

	public List<CRMspRpt_ChartActivityAndCallOutCallCntInLineInMonth_Result> NotUsed_ListOutCallCntInLineInMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallOutNotRegCall_Result> NotUsed_ListOutNotRegCall { get; set; }

	public List<CRMspRpt_ChartActivityAndCallOutNotRegCallInMonth_Result> NotUsed_ListOutNotRegCallInMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallOutRegCall_Result> NotUsed_ListOutRegCall { get; set; }

	public List<CRMspRpt_ChartActivityAndCallOutRegCallInMonth_Result> NotUsed_ListOutRegCallInMonth { get; set; }

	public List<CRMspRpt_ChartActivityAndCallToComp_Result> NotUsed_ListCallToComp { get; set; }

	public List<CRMspRpt_ChartActivityAndCallUserAllCnvsWeb_Result> NotUsed_ListUserAllCnvs { get; set; }
}
