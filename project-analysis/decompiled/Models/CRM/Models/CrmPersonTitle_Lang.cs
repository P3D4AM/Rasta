using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmPersonTitle_LangMetadata))]
public class CrmPersonTitle_Lang
{
	public int CrmPersonTitleLangID { get; set; }

	public int PersonTitleID { get; set; }

	public int LanguageID { get; set; }

	public string PersonTitle { get; set; }

	public virtual CrmPersonTitle CrmPersonTitle { get; set; }

	public virtual Languages Languages { get; set; }
}
