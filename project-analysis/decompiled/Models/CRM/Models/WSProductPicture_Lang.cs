using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductPicture_LangMetadata))]
public class WSProductPicture_Lang
{
	public int WSProductPictureLangID { get; set; }

	public int PrdPictureID { get; set; }

	public int LanguageID { get; set; }

	public string PrdFirstPicDesc { get; set; }

	public string PrdSecondPicDesc { get; set; }

	public string PrdThirdPicDesc { get; set; }

	public string PrdFourthPicDesc { get; set; }

	public string PrdFifthPicDesc { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductPicture WSProductPicture { get; set; }
}
