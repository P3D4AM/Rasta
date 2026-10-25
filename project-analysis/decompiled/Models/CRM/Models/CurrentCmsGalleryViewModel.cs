using System.Collections.Generic;

namespace CRM.Models;

public class CurrentCmsGalleryViewModel
{
	public CRMspCmsSelectGallery_Result Gallery { get; set; }

	public List<CRMspCmsSelectGalleryItems_Result> GalleryItems { get; set; }

	public int GalleryCurrentId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }
}
