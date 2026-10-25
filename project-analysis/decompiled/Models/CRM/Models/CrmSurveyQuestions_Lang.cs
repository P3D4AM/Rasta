using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyQuestions_LangMetadata))]
public class CrmSurveyQuestions_Lang
{
	public int CrmSurveyQuestionsLangID { get; set; }

	public int SurveyQuestionId { get; set; }

	public int LanguageID { get; set; }

	public string SurveyQuestion { get; set; }

	public virtual CrmSurveyQuestions CrmSurveyQuestions { get; set; }

	public virtual Languages Languages { get; set; }
}
