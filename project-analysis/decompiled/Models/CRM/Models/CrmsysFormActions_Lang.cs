using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysFormActions_LangMetadata))]
public class CrmsysFormActions_Lang
{
	public int CrmsysFormActionsLangID { get; set; }

	public int ID { get; set; }

	public int LanguageID { get; set; }

	public string ActionPersianName { get; set; }

	public string ActionGroupName { get; set; }

	public string ActionDesc { get; set; }

	public virtual CrmsysFormActions CrmsysFormActions { get; set; }

	public virtual Languages Languages { get; set; }
}
