using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyAnswerCategoryDetails_LangMetadata))]
public class CrmSurveyAnswerCategoryDetails_Lang
{
	public int CrmSurveyAnswerCategoryDetailLangID { get; set; }

	public int SurveyAnswerCategoryDetailId { get; set; }

	public string suracdDetailTitle { get; set; }

	public int LanguageID { get; set; }

	public virtual CrmSurveyAnswerCategoryDetails CrmSurveyAnswerCategoryDetails { get; set; }

	public virtual Languages Languages { get; set; }
}
