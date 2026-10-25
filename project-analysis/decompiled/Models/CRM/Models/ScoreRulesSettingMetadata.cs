using System;

namespace CRM.Models;

public class ScoreRulesSettingMetadata
{
	public int RuleSettingId { get; set; }

	public bool? UpdateCmpGroup { get; set; }

	public bool? UpdateCmpSubGroup { get; set; }

	public bool? UpdateCmpGroupII { get; set; }

	public bool? UpdateCmpGroupIII { get; set; }

	public bool? UpdateCmpGroupIV { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? UserId { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public Guid? GUId { get; set; }

	public int? CId { get; set; }

	public bool? UseFirstPriorityRule { get; set; }
}
