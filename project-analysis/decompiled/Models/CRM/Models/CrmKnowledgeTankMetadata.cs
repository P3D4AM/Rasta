using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmKnowledgeTankMetadata
{
	[Key]
	public int KnowledgeTankId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string knlgTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgSigns")]
	public string knlgSigns { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgKnowledge")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string knlgKnowledge { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgPriorityId")]
	public int? knlgPriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "knlgGroupId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int knlgGroupId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }
}
