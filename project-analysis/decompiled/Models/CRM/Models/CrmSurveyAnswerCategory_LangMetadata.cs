using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSurveyAnswerCategory_LangMetadata
{
	[Key]
	public int CrmSurveyAnswerCategoryLangID { get; set; }

	public int SurveyAnswerCategoryId { get; set; }

	public int LanguageID { get; set; }

	public string SurveyAnswerCategoryTitle { get; set; }
}
