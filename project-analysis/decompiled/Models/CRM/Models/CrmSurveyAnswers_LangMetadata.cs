using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSurveyAnswers_LangMetadata
{
	[Key]
	public int CrmSurveyAnswersLangID { get; set; }

	public int SurveyAnswerId { get; set; }

	public int LanguageID { get; set; }

	public string SurveyAnswer { get; set; }
}
