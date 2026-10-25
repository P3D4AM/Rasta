using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmUserNotesMetadata
{
	[Key]
	public int NoteId { get; set; }

	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Note")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Note { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Note1")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Note1 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Note2")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Note2 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "Note3")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Note3 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
