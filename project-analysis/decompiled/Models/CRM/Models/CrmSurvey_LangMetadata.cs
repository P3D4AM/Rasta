using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSurvey_LangMetadata
{
	[Key]
	public int CrmSurveyLangID { get; set; }

	public int SurveyId { get; set; }

	public int LanguageID { get; set; }

	public string surTitle { get; set; }

	public string surDesc { get; set; }
}
