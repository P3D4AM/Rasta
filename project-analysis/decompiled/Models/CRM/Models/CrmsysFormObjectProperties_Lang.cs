using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysFormObjectProperties_LangMetadata))]
public class CrmsysFormObjectProperties_Lang
{
	public int CrmsysFormObjectPropertiesLangID { get; set; }

	public int ID { get; set; }

	public int LanguageID { get; set; }

	public string ObjectPersianName { get; set; }

	public virtual CrmsysFormObjectProperties CrmsysFormObjectProperties { get; set; }

	public virtual Languages Languages { get; set; }
}
