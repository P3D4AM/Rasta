using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyAnswerCategory_LangMetadata))]
public class CrmSurveyAnswerCategory_Lang
{
	public int CrmSurveyAnswerCategoryLangID { get; set; }

	public int SurveyAnswerCategoryId { get; set; }

	public int LanguageID { get; set; }

	public string SurveyAnswerCategoryTitle { get; set; }

	public virtual CrmSurveyAnswerCategory CrmSurveyAnswerCategory { get; set; }

	public virtual Languages Languages { get; set; }
}
