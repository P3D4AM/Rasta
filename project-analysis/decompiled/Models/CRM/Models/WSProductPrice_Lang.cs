using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductPrice_LangMetadata))]
public class WSProductPrice_Lang
{
	public int WSProductPriceLangID { get; set; }

	public int PrdPriceID { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductPrice WSProductPrice { get; set; }
}
