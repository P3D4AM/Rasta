namespace Mobile.Models;

public class FOMobspDySelectFormFieldsWithFormId_Result
{
	public int FormFieldId { get; set; }

	public int ParentFormId { get; set; }

	public int FormId { get; set; }

	public int? FieldTypeId { get; set; }

	public int? ParentFieldId { get; set; }

	public string ParentFieldColor { get; set; }

	public string ParentFieldBgColor { get; set; }

	public string FieldTitle { get; set; }

	public bool? IsRequired { get; set; }

	public int? RegularExpressionId { get; set; }

	public string RegularExpressionErrorTxt { get; set; }

	public long? MinValue { get; set; }

	public long? MaxValue { get; set; }

	public long? StrLength { get; set; }

	public string PlaceholderTxt { get; set; }

	public string MultiItems { get; set; }

	public string DefaultValue { get; set; }

	public bool? IsActive { get; set; }

	public int? ColumnPosition { get; set; }

	public int? OrderView { get; set; }

	public string ParentForm { get; set; }

	public string FormName { get; set; }

	public string FieldType { get; set; }

	public string TypeInWeb { get; set; }

	public string TypeInWindows { get; set; }

	public string ParentField { get; set; }

	public string RegularExpressionTitle { get; set; }

	public string RegularExpression { get; set; }

	public string RegularExpressionOther { get; set; }
}
