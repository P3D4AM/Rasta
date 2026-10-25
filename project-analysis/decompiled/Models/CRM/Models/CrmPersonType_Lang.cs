using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmPersonType_LangMetadata))]
public class CrmPersonType_Lang
{
	public int CrmPersonTypeLangID { get; set; }

	public int PersonTypeID { get; set; }

	public int LanguageID { get; set; }

	public string PersonType { get; set; }

	public virtual CrmPersonType CrmPersonType { get; set; }

	public virtual Languages Languages { get; set; }
}
