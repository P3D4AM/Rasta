using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectInformations_LangMetadata))]
public class CrmProjectInformations_Lang
{
	public int ProjectInformationLangID { get; set; }

	public int ProjectInformationId { get; set; }

	public int LanguageID { get; set; }

	public string FieldValue { get; set; }

	public string Description { get; set; }

	public virtual CrmProjectInformations CrmProjectInformations { get; set; }

	public virtual Languages Languages { get; set; }
}
