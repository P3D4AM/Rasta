using System;

namespace CRM.Models;

public class mct_CRMspDySelectFormFieldValues_Result
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

	public int? FirstRegisterUserId { get; set; }

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

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FormName { get; set; }

	public string FieldTitle { get; set; }

	public string RegularExpressionErrorTxt { get; set; }

	public string FieldType { get; set; }

	public string TypeInWeb { get; set; }

	public string TypeInWindows { get; set; }

	public string RegularExpressionTitle { get; set; }

	public string RegularExpression { get; set; }

	public string RegularExpressionOther { get; set; }

	public int? FieldTypeId { get; set; }

	public int? MasterValueId { get; set; }
}
