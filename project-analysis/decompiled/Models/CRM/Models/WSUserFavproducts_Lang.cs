using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSUserFavproducts_LangMetadata))]
public class WSUserFavproducts_Lang
{
	public int WSUserFavproductsLangID { get; set; }

	public int UserFavproductId { get; set; }

	public int LanguageID { get; set; }

	public string FavprdTitle { get; set; }

	public string FavprdDesc { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSUserFavproducts WSUserFavproducts { get; set; }
}
