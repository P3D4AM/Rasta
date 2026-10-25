using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsGallery_LangMetadata))]
public class CrmCmsGallery_Lang
{
	public int CrmCmsGalleryLangID { get; set; }

	public int GalleryId { get; set; }

	public int LanguageID { get; set; }

	public string GalleryTitle { get; set; }

	public virtual CrmCmsGallery CrmCmsGallery { get; set; }

	public virtual Languages Languages { get; set; }
}
