using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmProjectTitlesViewModel
{
	[Key]
	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleID")]
	public int ProjectTitleID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitle")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ProjectTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleGroupId")]
	public string ProjectTitleGroupIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleStatusGroupId")]
	public string ProjectTitleStatusGroupIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleGradeId")]
	public string ProjectTitleGradeIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitlePriorityId")]
	public string ProjectTitlePriorityIdTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleDesc")]
	public string ProjectTitleDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleGroupId")]
	public int? ProjectTitleGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleStatusGroupId")]
	public int? ProjectTitleStatusGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitleGradeId")]
	public int? ProjectTitleGradeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjProjectTitlePriorityId")]
	public int? ProjectTitlePriorityId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public string AppType { get; set; }
}
