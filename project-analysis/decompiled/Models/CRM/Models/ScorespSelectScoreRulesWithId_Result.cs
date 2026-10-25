using System;

namespace CRM.Models;

public class ScorespSelectScoreRulesWithId_Result
{
	public int RuleId { get; set; }

	public string RuleTitle { get; set; }

	public int RuleSysPartId { get; set; }

	public double RuleScoreRate { get; set; }

	public decimal? RuleFromAmount { get; set; }

	public decimal? RuleToAmount { get; set; }

	public DateTime? RuleFromDate { get; set; }

	public string RuleFromDatePersian { get; set; }

	public DateTime? RuleToDate { get; set; }

	public string RuleToDatePersian { get; set; }

	public bool? RuleInActive { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public decimal? RuleFromTotalAmount { get; set; }

	public decimal? RuleToTotalAmount { get; set; }

	public decimal? RuleFromTotalCount { get; set; }

	public decimal? RuleToTotalCount { get; set; }

	public int? RuleDistanceDaysWithLastObj { get; set; }

	public string RulePrdIds { get; set; }

	public string RulePrds { get; set; }

	public bool? RulePayIsComplete { get; set; }

	public decimal? RuleScoreAmount { get; set; }

	public string RuleDyFormIds { get; set; }

	public string RuleDyForms { get; set; }

	public string RuleSurveyIds { get; set; }

	public string RuleSurveys { get; set; }

	public bool? RuleIsCmpScore { get; set; }

	public bool? RuleIsUserScore { get; set; }

	public string RuleUserScoreInfo { get; set; }

	public string RuleUserScoreInfoJs { get; set; }

	public decimal? RuleScoreAmountPercent { get; set; }

	public DateTime? RuleExpireDate { get; set; }

	public string RuleExpireDatePersian { get; set; }

	public int? RuleScoreExpireDay { get; set; }

	public DateTime? RuleScoreExpireDate { get; set; }

	public string RuleScoreExpireDatePersian { get; set; }

	public bool? RuleObjectIsVerified { get; set; }

	public bool? RuleCalcAutoScoreInIssue { get; set; }

	public bool? RuleCalcAutoScoreInVerify { get; set; }

	public string RuleCalcAutoScoreDailyTime { get; set; }

	public int? RuleCalcAutoScoreHourly { get; set; }

	public bool? RuleCalcAutoScoreSendNewTicket { get; set; }

	public bool? RuleCalcAutoScoreSurveyInsertData { get; set; }

	public bool? RuleCalcAutoScoreFODyFormInsertData { get; set; }

	public string RulePrdFGIds { get; set; }

	public string RulePrdSGIds { get; set; }

	public string RulePrdFGNames { get; set; }

	public string RulePrdSGNames { get; set; }

	public int? RuleCId { get; set; }

	public string RuleCenterName { get; set; }

	public bool? RuleUpdateCmpGroup { get; set; }

	public bool? RuleUpdateCmpSubGroup { get; set; }

	public bool? RuleUpdateCmpGroupII { get; set; }

	public bool? RuleUpdateCmpGroupIII { get; set; }

	public bool? RuleUpdateCmpGroupIV { get; set; }

	public bool? RuleToTotalAmountCalcWithRepeat { get; set; }

	public double? RuleRowCnt { get; set; }

	public bool? RuleRowCntCalcWithRepeat { get; set; }

	public double? RulePrdQty { get; set; }

	public bool? RulePrdQtyCalcWithRepeat { get; set; }

	public double? RulePrdSumQty { get; set; }

	public bool? RulePrdSumQtyCalcWithRepeat { get; set; }

	public int? RulePriority { get; set; }

	public string RuleAmountJson { get; set; }

	public int? RuleOrdTotalWithPrdMode { get; set; }

	public int? RuleOrdTotalWithPrdGroupMode { get; set; }

	public string RuleOprIds { get; set; }

	public string RuleStatusIds { get; set; }

	public string RuleOprNames { get; set; }

	public string RuleStatusTitles { get; set; }
}
