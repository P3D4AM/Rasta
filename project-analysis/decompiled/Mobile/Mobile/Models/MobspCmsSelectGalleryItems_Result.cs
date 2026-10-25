namespace Mobile.Models;

public class MobspCmsSelectGalleryItems_Result
{
	public int GalleryItemId { get; set; }

	public int GalleryId { get; set; }

	public string ItemTitle { get; set; }

	public string ItemDesc { get; set; }

	public string ItemTitleFontColor { get; set; }

	public string ItemDescFontColor { get; set; }

	public string ItemLink { get; set; }

	public string ItemLinkTitle { get; set; }

	public string ItemLinkBgColor { get; set; }

	public string ItemLinkFontColor { get; set; }

	public int? TargetMode { get; set; }

	public bool? IsActive { get; set; }

	public bool? IsShowTitle { get; set; }

	public bool? IsShowDesc { get; set; }

	public string FileName { get; set; }

	public string FolderName { get; set; }

	public string FilePath { get; set; }
}
