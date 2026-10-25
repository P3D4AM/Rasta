using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderItemSerials_LangMetadata))]
public class WSOrderItemSerials_Lang
{
	public int WSOrderItemSerialsLangID { get; set; }

	public int OrderItemSerialID { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderItemSerials WSOrderItemSerials { get; set; }
}
