using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class KnowledgeTankGroupLanguageViewModel
{
	[Key]
	public int KnowledgeTankGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "KnowledgeTankGroupTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string KnowledgeTankGroupTitle { get; set; }

	public string KnowledgeTankGroupDesc { get; set; }

	public int? KnowledgeTankGroupOrderView { get; set; }

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

	[Display(ResourceType = typeof(Labels), Name = "KnowledgeTankGroupFOCmpCanSee")]
	public bool? KnowledgeTankGroupFOCmpCanSee { get; set; }

	public string KnowledgeTankGroupTitle_Lang { get; set; }
}
