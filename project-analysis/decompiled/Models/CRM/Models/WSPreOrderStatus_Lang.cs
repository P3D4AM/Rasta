using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderStatus_LangMetadata))]
public class WSPreOrderStatus_Lang
{
	public int WSPreOrderStatusLangID { get; set; }

	public int PreOrderStatusId { get; set; }

	public int LanguageID { get; set; }

	public string PreOrderStatus { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderStatus WSPreOrderStatus { get; set; }
}
