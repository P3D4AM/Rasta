using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderItems_LangMetadata))]
public class WSOrderItems_Lang
{
	public int WSOrderItemsLangID { get; set; }

	public int OrderItemID { get; set; }

	public string ordIDescription { get; set; }

	public string ordIQuantityDesc { get; set; }

	public int LanguageID { get; set; }

	public string ordIPrdNickname { get; set; }

	public string ordIDiscountDesc { get; set; }

	public string ordIDescriptionI { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderItems WSOrderItems { get; set; }
}
