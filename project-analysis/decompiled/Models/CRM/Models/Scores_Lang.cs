using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(Scores_LangMetadata))]
public class Scores_Lang
{
	public int ScoreLangId { get; set; }

	public int ScoreId { get; set; }

	public int LanguageID { get; set; }

	public string ScoreDescription { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Scores Scores { get; set; }
}
