using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmProjectFieldTitleMetadata
{
	[Key]
	public int ProjectFieldTitleId { get; set; }

	public int? ProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectFieldTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FieldTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectFieldIsDefualt")]
	public bool? IsDefualtField { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectFieldValueType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ValueType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectFieldSortCode")]
	public int? SortCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ProjectFieldDescription")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
