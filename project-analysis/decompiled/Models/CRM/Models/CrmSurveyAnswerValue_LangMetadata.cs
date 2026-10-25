using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmSurveyAnswerValue_LangMetadata
{
	[Key]
	public int CrmSurveyAnswerValueLangID { get; set; }

	public int SurveyAnswerValueId { get; set; }

	public int LanguageID { get; set; }

	public string suravTextValue { get; set; }
}
