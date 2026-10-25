using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(ScoreRules_LangMetadata))]
public class ScoreRules_Lang
{
	public int ScoreRulesLangID { get; set; }

	public int RuleId { get; set; }

	public int LanguageID { get; set; }

	public string RuleTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ScoreRules ScoreRules { get; set; }
}
