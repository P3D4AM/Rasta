using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmProjectTitlesLanguageViewModel
{
	[Key]
	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleID")]
	public int ProjectTitleID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ProjectTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleGroupId")]
	public int? ProjectTitleGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleStatusGroupId")]
	public int? ProjectTitleStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleGradeId")]
	public int? ProjectTitleGradeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitlePriorityId")]
	public int? ProjectTitlePriorityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleDesc")]
	public string ProjectTitleDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public Guid? GUId { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitlePrjTitleGroupId")]
	public int? PrjTitleGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitlePrjPostFix")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrjPostFix { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitlePrjRemindDay")]
	public int? PrjRemindDay { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitlePrjFOCmpCanSee")]
	public bool? PrjFOCmpCanSee { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitlePrjIsTicket")]
	public bool? PrjIsTicket { get; set; }

	public string ProjectTitle_Lang { get; set; }

	public string ProjectTitleDesc_Lang { get; set; }

	public string PrjPostFix_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ActivePrjNumRWithTitle")]
	public bool? ActivePrjNumRWithTitle { get; set; }
}
