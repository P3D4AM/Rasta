using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSGuaranty_LangMetadata))]
public class WSGuaranty_Lang
{
	public int WSGuarantyLangID { get; set; }

	public int GuarantyID { get; set; }

	public int LanguageID { get; set; }

	public string Guaranty { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSGuaranty WSGuaranty { get; set; }
}
