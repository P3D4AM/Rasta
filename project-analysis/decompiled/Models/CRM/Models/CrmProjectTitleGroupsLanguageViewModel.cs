using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CRM.Resources;

namespace CRM.Models;

public class CrmProjectTitleGroupsLanguageViewModel
{
	[Key]
	public int ProjectTitleGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleGroupTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ProjectTitleGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleGroupDesc")]
	[UIHint("RichText")]
	[AllowHtml]
	public string ProjectTitleGroupDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleGroupUserDepartment")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ProjectTitleGroupUserDepartmentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleGroupAgreementActive")]
	public bool? ProjectTitleGroupAgreementActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleGroupAgreementDesc")]
	[UIHint("RichText")]
	[AllowHtml]
	public string ProjectTitleGroupAgreementDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleGroupSubjectDefaultContext")]
	public string ProjectTitleGroupSubjectDefaultContext { get; set; }

	public string ProjectTitleGroupSubjectDefaultContextJson { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleGroupTicketCountCurrentWithStop")]
	public bool? ProjectTitleGroupTicketCountCurrentWithStop { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectTitleGroupTicketAllowInCurrentCount")]
	public int? ProjectTitleGroupTicketAllowInCurrentCount { get; set; }

	public string ProjectTitleGroupColor { get; set; }

	public string ProjectTitleGroup_Lang { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string ProjectTitleGroupDesc_Lang { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string ProjectTitleGroupAgreementDesc_Lang { get; set; }

	public string ProjectTitleGroupSubjectDefaultContext_Lang { get; set; }
}
