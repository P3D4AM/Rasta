using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSurveyQuestions_LangMetadata
{
	[Key]
	public int CrmSurveyQuestionsLangID { get; set; }

	public int SurveyQuestionId { get; set; }

	public int LanguageID { get; set; }

	public string SurveyQuestion { get; set; }
}
