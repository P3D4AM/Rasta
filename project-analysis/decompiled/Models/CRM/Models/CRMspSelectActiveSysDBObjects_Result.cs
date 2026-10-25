using System;

namespace CRM.Models;

public class CRMspSelectActiveSysDBObjects_Result
{
	public int DBObjectId { get; set; }

	public string DBObjectName { get; set; }

	public string FieldName { get; set; }

	public string FieldTitle { get; set; }

	public bool? NotNull { get; set; }

	public int? OrderView { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? FieldDataTypeId { get; set; }

	public string FieldDataType { get; set; }

	public string FieldElementTypeWeb { get; set; }

	public string FieldRegEx { get; set; }

	public string FieldTitleCustom { get; set; }

	public string EventsJson { get; set; }

	public string AdditionalButtonsJson { get; set; }

	public string FieldDescription { get; set; }

	public bool? InActive { get; set; }

	public int? FieldClass { get; set; }

	public string FieldGroupBoxName { get; set; }

	public string FieldUsedType { get; set; }

	public bool? FieldFromTo { get; set; }

	public bool? FieldMulti { get; set; }

	public string FieldNameRefs { get; set; }
}
