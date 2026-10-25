using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductColor_LangMetadata))]
public class WSProductColor_Lang
{
	public int WSProductColorLangID { get; set; }

	public int ProductColorID { get; set; }

	public int LanguageID { get; set; }

	public string Color { get; set; }

	public string ColorDescription { get; set; }

	public string ColorEn { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductColor WSProductColor { get; set; }
}
