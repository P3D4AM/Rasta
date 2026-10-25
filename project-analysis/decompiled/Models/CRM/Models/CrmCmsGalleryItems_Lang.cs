using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsGalleryItems_LangMetadata))]
public class CrmCmsGalleryItems_Lang
{
	public int CrmCmsGalleryItemLangID { get; set; }

	public int GalleryItemId { get; set; }

	public int LanguageID { get; set; }

	public string ItemTitle { get; set; }

	public string ItemDesc { get; set; }

	public string ItemLinkTitle { get; set; }

	public virtual CrmCmsGalleryItems CrmCmsGalleryItems { get; set; }

	public virtual Languages Languages { get; set; }
}
