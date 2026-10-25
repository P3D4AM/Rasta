namespace Mobile.Models;

public class MobspSelectProductGroupPictureByPrdGroupId_Result
{
	public int ProductGroupPictureId { get; set; }

	public int PrdGroupId { get; set; }

	public byte[] PrdGroupPic { get; set; }

	public int? Type { get; set; }

	public string FolderName { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public int? FirstGroupId { get; set; }
}
