using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class PrintFormatLanguageViewModel
{
	[Key]
	public int PrintFormatID { get; set; }

	public int PrintFormatTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrintFormatTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Title { get; set; }

	public string FileName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrintFormatFileName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FileNameWeb { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CId { get; set; }

	public int? SysPartId { get; set; }

	public int? SysPartObjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrintFormatIsDefault")]
	public bool? IsDefault { get; set; }

	public string Title_Lang { get; set; }
}
