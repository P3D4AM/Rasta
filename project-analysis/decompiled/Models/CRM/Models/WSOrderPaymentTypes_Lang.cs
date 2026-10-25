using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderPaymentTypes_LangMetadata))]
public class WSOrderPaymentTypes_Lang
{
	public int WSOrderPaymentTypesLangID { get; set; }

	public int OrderPaymentTypeId { get; set; }

	public int LanguageID { get; set; }

	public string ordpayType { get; set; }

	public string ordpayTypeDescription { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderPaymentTypes WSOrderPaymentTypes { get; set; }
}
