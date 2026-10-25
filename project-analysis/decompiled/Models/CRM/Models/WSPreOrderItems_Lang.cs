using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderItems_LangMetadata))]
public class WSPreOrderItems_Lang
{
	public int WSPreOrderItemsLangID { get; set; }

	public int PreOrderItemID { get; set; }

	public int LanguageID { get; set; }

	public string pordIDescription { get; set; }

	public string pordIQuantityDesc { get; set; }

	public string pordIPrdNickname { get; set; }

	public string pordIDiscountDesc { get; set; }

	public string pordIDescriptionI { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderItems WSPreOrderItems { get; set; }
}
