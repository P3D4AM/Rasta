using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class ScoreRulesMetadata
{
	[Key]
	public int RuleId { get; set; }

	public string RuleTitle { get; set; }

	public int RuleSysPartId { get; set; }

	public double RuleScoreNumber { get; set; }

	public double? RuleFromQty { get; set; }

	public double? RuleToQty { get; set; }

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
}
