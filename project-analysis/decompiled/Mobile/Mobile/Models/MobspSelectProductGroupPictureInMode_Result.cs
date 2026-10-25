namespace Mobile.Models;

public class MobspSelectProductGroupPictureInMode_Result
{
	public int ProductGroupPictureId { get; set; }

	public int PrdGroupId { get; set; }

	public byte[] PrdGroupPic { get; set; }

	public string FolderName { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public int? FirstGroupId { get; set; }
}
