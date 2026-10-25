using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmProjectDefualtValue_LangMetadata))]
public class CrmProjectDefualtValue_Lang
{
	public int ProjectDefualtValueLangID { get; set; }

	public int ProjectDefualtValueId { get; set; }

	public int LanguageID { get; set; }

	public string DefualtValue { get; set; }

	public string Description { get; set; }

	public virtual CrmProjectDefualtValue CrmProjectDefualtValue { get; set; }

	public virtual Languages Languages { get; set; }
}
