using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmTimeAttendanceBaseMetadata
{
	[Key]
	public int TimeAttendanceBaseId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbDay")]
	public int tmbDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbEntryBase")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string tmbEntryBase { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbEntryAllowMin")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int tmbEntryAllowMin { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbExitBase")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string tmbExitBase { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "tmbExitAllowMin")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int tmbExitAllowMin { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
