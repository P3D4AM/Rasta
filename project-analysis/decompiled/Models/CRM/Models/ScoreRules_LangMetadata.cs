using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class ScoreRules_LangMetadata
{
	[Key]
	public int ScoreRulesLangID { get; set; }

	public int RuleId { get; set; }

	public int LanguageID { get; set; }

	public string RuleTitle { get; set; }
}
