using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSurveyAnswerCategoryDetails_LangMetadata
{
	[Key]
	public int CrmSurveyAnswerCategoryDetailLangID { get; set; }

	public int SurveyAnswerCategoryDetailId { get; set; }

	public string suracdDetailTitle { get; set; }

	public int LanguageID { get; set; }
}
