using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDocItemSerials_LangMetadata))]
public class WSDocItemSerials_Lang
{
	public int WSDocItemSerialsLangID { get; set; }

	public int DocItemSerialID { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public string InfoI { get; set; }

	public string InfoII { get; set; }

	public string InfoIII { get; set; }

	public string InfoIV { get; set; }

	public string InfoV { get; set; }

	public string InfoVI { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDocItemSerials WSDocItemSerials { get; set; }
}
