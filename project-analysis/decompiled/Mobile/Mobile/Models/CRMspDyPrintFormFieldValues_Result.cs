using System;

namespace Mobile.Models;

public class CRMspDyPrintFormFieldValues_Result
{
	public int FormFieldValueId { get; set; }

	public int? FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public int FieldId { get; set; }

	public long? FieldRepeatId { get; set; }

	public string FieldTitle { get; set; }

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

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string RegisterUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string rptUserName { get; set; }

	public int? rptUserId { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string ValueTitle { get; set; }
}
