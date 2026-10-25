using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmFilesDirectoryViewModel
{
	[Key]
	public int FileDirectoryID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfFileDirectoryTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? FileDirectoryTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfFileDirectoryTypeId")]
	public string FileDirectoryTypeIdTitle { get; set; }

	public int? MasterId { get; set; }

	public int? DetailId { get; set; }

	public int? SubDetailId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Title { get; set; }

	public string FolderName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfFileName")]
	public string FileName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfFilePath")]
	public string FilePath { get; set; }

	public string CopyFromPath { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfDocDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string DocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfDocDay")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string DocDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfDocTime")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string DocTime { get; set; }

	public Guid? GUId { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int? TypeOprObjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfCompanyId")]
	public int CompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfCompanyId")]
	public string CompanyIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfProjectsId")]
	public int ProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfProjectsId")]
	public string ProjectIdTitle { get; set; }

	public virtual Users Users { get; set; }

	public string FileDirectoryTypeOpr { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "shfFileDirectoryNumRef")]
	public string FileDirectoryNumRef { get; set; }

	public int? TypeOprObjectIdI { get; set; }

	public int? TypeOprObjectIdII { get; set; }

	public string PaymentType { get; set; }

	public string FileDesc { get; set; }

	public string FileDesc_Lang { get; set; }
}
