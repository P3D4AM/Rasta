using System.Collections.Generic;

namespace Mobile.Models;

public class FoGetHomeGallery
{
	public FOMobspCmsSelectGallery_Result Gallery { get; set; }

	public List<FOMobspCmsSelectGalleryItems_Result> GalleryItems { get; set; }

	public bool IsFind { get; set; }

	public string GalleryName { get; set; }
}
