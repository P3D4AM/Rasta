using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductGroupPictureViewModel
{
	public int ProductGroupPictureId { get; set; }

	public int PrdGroupId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "frmErrorEmpty")]
	public string PrdGroupPic { get; set; }

	public int? Type { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string AppType { get; set; }

	public string FirstRegisterInfo { get; set; }

	public string EditInfo { get; set; }

	public string FolderName { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public int? FirstGroupId { get; set; }
}
