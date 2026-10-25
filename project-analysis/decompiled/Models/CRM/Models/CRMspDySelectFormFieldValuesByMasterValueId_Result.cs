namespace CRM.Models;

public class CRMspDySelectFormFieldValuesByMasterValueId_Result
{
	public int FormFieldValueId { get; set; }

	public int FormId { get; set; }

	public int FieldId { get; set; }

	public string Value { get; set; }

	public bool? IsDeleted { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? ConversationId { get; set; }

	public int? MasterObjectId { get; set; }

	public int? DetailObjectId { get; set; }

	public int? SubDetailObjectId { get; set; }

	public int MasterValueId { get; set; }

	public string FormName { get; set; }

	public string FieldTitle { get; set; }

	public string RegularExpressionErrorTxt { get; set; }

	public int? FieldTypeId { get; set; }

	public string ValueTitle { get; set; }

	public string FieldType { get; set; }

	public string TypeInWeb { get; set; }

	public string TypeInWindows { get; set; }

	public string RegularExpressionTitle { get; set; }

	public string RegularExpression { get; set; }

	public string RegularExpressionOther { get; set; }

	public string Value_Lang { get; set; }

	public long? FieldRepeatId { get; set; }

	public int? ParentFieldId { get; set; }

	public string ChangeHistory { get; set; }
}
