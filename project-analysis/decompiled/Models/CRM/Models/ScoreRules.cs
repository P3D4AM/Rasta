using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(ScoreRulesMetadata))]
public class ScoreRules
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

	public decimal? RuleFromTotalAmount { get; set; }

	public decimal? RuleToTotalAmount { get; set; }

	public decimal? RuleFromTotalCount { get; set; }

	public decimal? RuleToTotalCount { get; set; }

	public int? RuleDistanceDaysWithLastObj { get; set; }

	public string RulePrdIds { get; set; }

	public bool? RulePayIsComplete { get; set; }

	public double? RuleRowCnt { get; set; }

	public decimal? RuleScoreAmount { get; set; }

	public string RuleDyFormIds { get; set; }

	public string RuleSurveyIds { get; set; }

	public bool? RuleIsCmpScore { get; set; }

	public bool? RuleIsUserScore { get; set; }

	public string RuleUserScoreInfo { get; set; }

	public decimal? RuleScoreAmountPercent { get; set; }

	public DateTime? RuleExpireDate { get; set; }

	public string RuleExpireDatePersian { get; set; }

	public int? RuleScoreExpireDay { get; set; }

	public DateTime? RuleScoreExpireDate { get; set; }

	public string RuleScoreExpireDatePersian { get; set; }

	public double? RulePrdQty { get; set; }

	public bool? RulePrdQtyCalcWithRepeat { get; set; }

	public bool? RuleRowCntCalcWithRepeat { get; set; }

	public bool? RuleObjectIsVerified { get; set; }

	public bool? RuleCalcAutoScoreInIssue { get; set; }

	public bool? RuleCalcAutoScoreInVerify { get; set; }

	public string RuleCalcAutoScoreDailyTime { get; set; }

	public int? RuleCalcAutoScoreHourly { get; set; }

	public double? RulePrdSumQty { get; set; }

	public bool? RulePrdSumQtyCalcWithRepeat { get; set; }

	public bool? RuleCalcAutoScoreSendNewTicket { get; set; }

	public bool? RuleCalcAutoScoreSurveyInsertData { get; set; }

	public bool? RuleCalcAutoScoreFODyFormInsertData { get; set; }

	public string RulePrdFGIds { get; set; }

	public string RulePrdSGIds { get; set; }

	public int? RuleCId { get; set; }

	public bool? RuleUpdateCmpGroup { get; set; }

	public bool? RuleUpdateCmpSubGroup { get; set; }

	public bool? RuleUpdateCmpGroupII { get; set; }

	public bool? RuleUpdateCmpGroupIII { get; set; }

	public bool? RuleUpdateCmpGroupIV { get; set; }

	public bool? RuleToTotalAmountCalcWithRepeat { get; set; }

	public int? RulePriority { get; set; }

	public string RuleAmountJson { get; set; }

	public int? RuleOrdTotalWithPrdMode { get; set; }

	public int? RuleOrdTotalWithPrdGroupMode { get; set; }

	public string RuleOprIds { get; set; }

	public string RuleStatusIds { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<ScoreRules_Lang> ScoreRules_Lang { get; set; }

	public virtual ICollection<Scores> Scores { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public ScoreRules()
	{
		ScoreRules_Lang = (ICollection<ScoreRules_Lang>)new HashSet<ScoreRules_Lang>();
		Scores = (ICollection<Scores>)new HashSet<Scores>();
	}
}
