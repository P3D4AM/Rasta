using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSUserFavproductItems_LangMetadata))]
public class WSUserFavproductItems_Lang
{
	public int WSUserFavproductItemsLangID { get; set; }

	public int UserFavproductItemId { get; set; }

	public int LanguageID { get; set; }

	public string FavprdIQuantityDesc { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSUserFavproductItems WSUserFavproductItems { get; set; }
}
