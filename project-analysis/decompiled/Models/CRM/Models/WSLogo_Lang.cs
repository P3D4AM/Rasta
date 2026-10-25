using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSLogo_LangMetadata))]
public class WSLogo_Lang
{
	public int WSLogoLangID { get; set; }

	public int LogoID { get; set; }

	public int LanguageID { get; set; }

	public string LogoDescription { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSLogo WSLogo { get; set; }
}
