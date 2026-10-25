using System;

namespace CRM.Models;

public class WSspSelectProductGroupPicture_Result
{
	public int ProductGroupPictureId { get; set; }

	public int PrdGroupId { get; set; }

	public byte[] PrdGroupPic { get; set; }

	public int? Type { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FolderName { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public int? FirstGroupId { get; set; }
}
