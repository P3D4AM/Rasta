using System;

namespace CRM.Models;

public class CRMspSelectImportExcelFields_Result
{
	public int Id { get; set; }

	public int SystemPartId { get; set; }

	public string SystemPart { get; set; }

	public int? SystemPartGroupId { get; set; }

	public string SystemPartGroupCaption { get; set; }

	public string FieldName { get; set; }

	public string FieldCaption { get; set; }

	public string FieldDesc { get; set; }

	public int? FieldTypeId { get; set; }

	public string FieldTypeName { get; set; }

	public string FieldTypeCaption { get; set; }

	public string FieldTypeRegEx { get; set; }

	public int? FieldSize { get; set; }

	public bool? InActive { get; set; }

	public bool? NotNull { get; set; }

	public bool? Selector { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public string AppType { get; set; }

	public int? RegisterUserId { get; set; }

	public string EditUser { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
