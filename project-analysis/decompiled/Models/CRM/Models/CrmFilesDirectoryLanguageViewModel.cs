using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFilesDirectoryLanguageViewModel
{
	[Key]
	public int FileDirectoryID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfFileDirectoryTypeId")]
	public int? FileDirectoryTypeId { get; set; }

	public int? MasterId { get; set; }

	public int? DetailId { get; set; }

	public int? SubDetailId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Title { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Description")]
	public string Desc { get; set; }

	public string FolderName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfFileName")]
	public string FileName { get; set; }

	public string FilePath { get; set; }

	public string CopyFromPath { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string DocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfDocDay")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string DocDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfDocTime")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[RegularExpression("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string DocTime { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfDocDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public DateTime? DocDateTime { get; set; }

	public int? TypeOprObjectId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int SelectedFileFromKnlg { get; set; }

	public string Title_Lang { get; set; }

	public string Desc_Lang { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string AppTypeHelp { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int FileDirectoryTypeOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FileDirectoryNumRef")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FileDirectoryNumRef { get; set; }

	public string FilesPath { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfFileFOCmpCanSee")]
	public bool? FileFOCmpCanSee { get; set; }

	public int? groupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfIsUseSameTitle")]
	public bool? IsUseSameTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "lblMobHRMVisible")]
	public bool? MobHRMVisible { get; set; }
}
