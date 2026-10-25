using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderTypes_LangMetadata))]
public class WSPreOrderTypes_Lang
{
	public int WSPreOrderTypeLangID { get; set; }

	public int PreOrderTypeId { get; set; }

	public int LanguageID { get; set; }

	public string PreOrderType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderTypes WSPreOrderTypes { get; set; }
}
