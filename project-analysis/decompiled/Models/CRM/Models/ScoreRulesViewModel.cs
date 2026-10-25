using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class ScoreRulesViewModel
{
	[Key]
	public int RuleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRuleTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	public string RuleTitle { get; set; }

	public string RuleTitle_Lang { get; set; }

	public int RuleSysPartId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRuleScoreNumber")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public double RuleScoreRate { get; set; }

	public double? RuleFromQty { get; set; }

	public double? RuleToQty { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRuleFromAmount")]
	public decimal? RuleFromAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRuleToAmount")]
	public decimal? RuleToAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRuleFromDate")]
	public DateTime? RuleFromDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRuleFromDate")]
	public string RuleFromDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRuleToDate")]
	public DateTime? RuleToDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRuleToDate")]
	public string RuleToDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRuleInActive")]
	public bool? RuleInActive { get; set; }

	public int? OrderView { get; set; }

	public decimal? RuleFromTotalAmount { get; set; }

	public decimal? RuleToTotalAmount { get; set; }

	public decimal? RuleFromTotalCount { get; set; }

	public decimal? RuleToTotalCount { get; set; }

	public int? RuleDistanceDaysWithLastObj { get; set; }

	public string RulePrdIds { get; set; }

	public string RulePrds { get; set; }

	public bool? RulePayIsComplete { get; set; }

	public int? RuleValidityDay { get; set; }

	public bool? RuleOverlapOtherRules { get; set; }

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

	public double? RuleRowCnt { get; set; }

	public double? RulePrdQty { get; set; }

	public bool? RulePrdQtyCalcWithRepeat { get; set; }

	public bool? RuleRowCntCalcWithRepeat { get; set; }

	public bool? RuleObjectIsVerified { get; set; }

	public int? RuleCalcScoreType { get; set; }

	public bool? RuleCalcAutoScoreInIssue { get; set; }

	public bool? RuleCalcAutoScoreInVerify { get; set; }

	public string RuleCalcAutoScoreDailyTime { get; set; }

	public int? RuleCalcAutoScoreHourly { get; set; }

	public bool? RuleCalcAutoScoreSendNewTicket { get; set; }

	public bool? RuleCalcAutoScoreFODyFormInsertData { get; set; }

	public bool? RuleCalcAutoScoreSurveyInsertData { get; set; }

	public double? RulePrdSumQty { get; set; }

	public bool? RulePrdSumQtyCalcWithRepeat { get; set; }

	public string RulePrdFGIds { get; set; }

	public string RulePrdSGIds { get; set; }

	public int? RuleCId { get; set; }

	public string RuleCenterName { get; set; }

	public bool? RuleUpdateCmpGroup { get; set; }

	public bool? RuleUpdateCmpSubGroup { get; set; }

	public bool? RuleUpdateCmpGroupII { get; set; }

	public bool? RuleUpdateCmpGroupIII { get; set; }

	public bool? RuleUpdateCmpGroupIV { get; set; }

	public bool? RuleToTotalAmountCalcWithRepeat { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreRulePriority")]
	public int? RulePriority { get; set; }

	public string RuleAmountJson { get; set; }

	public int? RuleOrdTotalWithPrdMode { get; set; }

	public int? RuleOrdTotalWithPrdGroupMode { get; set; }

	public string RuleOprIds { get; set; }

	public string RuleStatusIds { get; set; }

	public string RuleOprNames { get; set; }

	public string RuleStatusTitles { get; set; }
}
