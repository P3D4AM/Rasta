using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmSurvey_LangMetadata))]
public class CrmSurvey_Lang
{
	public int CrmSurveyLangID { get; set; }

	public int SurveyId { get; set; }

	public int LanguageID { get; set; }

	public string surTitle { get; set; }

	public string surDesc { get; set; }

	public virtual CrmSurvey CrmSurvey { get; set; }

	public virtual Languages Languages { get; set; }
}
