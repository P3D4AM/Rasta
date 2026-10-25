using System;

namespace CRMIdealApi.ApiModels;

public class ApispDySelectFormFields_Result
{
	public int ApiFormFieldId { get; set; }

	public int ApiParentFormId { get; set; }

	public int ApiFormId { get; set; }

	public int? ApiFieldTypeId { get; set; }

	public string ApiFieldType { get; set; }

	public int? ApiParentFieldId { get; set; }

	public string ApiParentFieldColor { get; set; }

	public string ApiParentFieldBgColor { get; set; }

	public string ApiFieldTitle { get; set; }

	public bool? ApiIsRequired { get; set; }

	public int? ApiRegularExpressionId { get; set; }

	public string ApiRegularExpression { get; set; }

	public string ApiRegularExpressionErrorTxt { get; set; }

	public long? ApiMinValue { get; set; }

	public long? ApiMaxValue { get; set; }

	public long? ApiStrLength { get; set; }

	public string ApiPlaceholderTxt { get; set; }

	public string ApiMultiItems { get; set; }

	public string ApiDefaultValue { get; set; }

	public bool? ApiIsActive { get; set; }

	public int? ApiColumnPosition { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }

	public int ApiEditUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public int? ApiRowPosition { get; set; }

	public bool? ApiIsRepeatable { get; set; }

	public bool? ApiFOIsRepeatable { get; set; }

	public int? ApiUploadFileMaxSize { get; set; }

	public string ApiUploadFileExtension { get; set; }
}
