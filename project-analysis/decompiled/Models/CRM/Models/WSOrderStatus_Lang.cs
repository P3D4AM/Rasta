using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderStatus_LangMetadata))]
public class WSOrderStatus_Lang
{
	public int WSOrderStatusLangID { get; set; }

	public int OrderStatusId { get; set; }

	public int LanguageID { get; set; }

	public string OrderStatus { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderStatus WSOrderStatus { get; set; }
}
