namespace CRM.Models;

public class WSspSelectProductGalleryByPrdGroupId_Result
{
	public int ProductGalleryId { get; set; }

	public int PrdId { get; set; }

	public bool? IsMain { get; set; }

	public string FolderName { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public int? OrderView { get; set; }
}
