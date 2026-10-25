using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDeliveryTerms_LangMetadata))]
public class WSDeliveryTerms_Lang
{
	public int WSDeliveryTermLangID { get; set; }

	public int DeliveryTermId { get; set; }

	public int LanguageID { get; set; }

	public string DeliveryTerm { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDeliveryTerms WSDeliveryTerms { get; set; }
}
