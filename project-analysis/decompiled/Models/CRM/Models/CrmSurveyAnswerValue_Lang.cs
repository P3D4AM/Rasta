using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurveyAnswerValue_LangMetadata))]
public class CrmSurveyAnswerValue_Lang
{
	public int CrmSurveyAnswerValueLangID { get; set; }

	public int SurveyAnswerValueId { get; set; }

	public int LanguageID { get; set; }

	public string suravTextValue { get; set; }

	public virtual CrmSurveyAnswerValue CrmSurveyAnswerValue { get; set; }

	public virtual Languages Languages { get; set; }
}
