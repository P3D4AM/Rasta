using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyAnswers_LangMetadata))]
public class CrmSurveyAnswers_Lang
{
	public int CrmSurveyAnswersLangID { get; set; }

	public int SurveyAnswerId { get; set; }

	public int LanguageID { get; set; }

	public string SurveyAnswer { get; set; }

	public virtual CrmSurveyAnswers CrmSurveyAnswers { get; set; }

	public virtual Languages Languages { get; set; }
}
