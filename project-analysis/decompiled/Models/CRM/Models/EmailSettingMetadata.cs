using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

internal class EmailSettingMetadata
{
	[Key]
	public int EmailSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailBulkingIsActive")]
	public bool? EmailBulkingIsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailBulkingDelayTime")]
	public int? EmailBulkingDelayTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailBulkingDailyStarTime")]
	public string EmailBulkingDailyStarTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailBulkingDailyEndTime")]
	public string EmailBulkingDailyEndTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailsAttachFilePath")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailsAttachFilePath { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailsAttachShareFilePath")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailsAttachShareFilePath { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailCmpPattern")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpPattern { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailCmpPrsPattern")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpPrsPattern { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailCmpPrsJobPattern")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CmpPrsJobPattern { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailSU")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailSU { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailSP")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailSP { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailSenderEditorFilePath")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailSenderEditorFilePath { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailsPDFBodyFilePath")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailsPDFBodyFilePath { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailsAttachShareFilePathFtp")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailsAttachShareFilePathFtp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "EmailsPDFBodyFilePathFtp")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string EmailsPDFBodyFilePathFtp { get; set; }

	public string AppType { get; set; }
}
