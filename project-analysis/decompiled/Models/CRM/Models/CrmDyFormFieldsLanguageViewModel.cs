using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmDyFormFieldsLanguageViewModel
{
	[Key]
	public int FormFieldId { get; set; }

	public int ParentFormId { get; set; }

	public int FormId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? FieldTypeId { get; set; }

	public int? ParentFieldId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormParentFieldColor")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ParentFieldColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormParentFieldBgColor")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ParentFieldBgColor { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldTitle")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string FieldTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldIsRequired")]
	public bool? IsRequired { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldRegularExpressionId")]
	public int? RegularExpressionId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldRegularExpressionErrorTxt")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string RegularExpressionErrorTxt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldMinValue")]
	public long? MinValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldMaxValue")]
	public long? MaxValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldStrLength")]
	public long? StrLength { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldPlaceholderTxt")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PlaceholderTxt { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldMultiItems")]
	public string MultiItems { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldDefaultValue")]
	public string DefaultValue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldIsActive")]
	public bool? IsActive { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldColumnPosition")]
	public int? ColumnPosition { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldOrderView")]
	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FieldTitle_Lang { get; set; }

	public string RegularExpressionErrorTxt_Lang { get; set; }

	public string PlaceholderTxt_Lang { get; set; }

	public string MultiItems_Lang { get; set; }

	public string DefaultValue_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldRowPosition")]
	public int? RowPosition { get; set; }

	public string MultiItem_Lang_Js { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldIsRepeatable")]
	public bool? IsRepeatable { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldFOIsRepeatable")]
	public bool? FOIsRepeatable { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldUploadFileMaxSize")]
	public int? UploadFileMaxSize { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldUploadFileExtension")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string UploadFileExtension { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DyFormFieldLinkDbObjectId")]
	public int? LinkDbObjectId { get; set; }
}
