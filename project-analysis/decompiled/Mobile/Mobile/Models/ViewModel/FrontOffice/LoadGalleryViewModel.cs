using System.Collections.Generic;

namespace Mobile.Models.ViewModel.FrontOffice;

public class LoadGalleryViewModel
{
	public MobspCmsSelectGallery_Result Gallery { get; set; }

	public List<MobspCmsSelectGalleryItems_Result> GalleryItems { get; set; }

	public bool IsFind { get; set; }

	public string GalleryName { get; set; }
}
