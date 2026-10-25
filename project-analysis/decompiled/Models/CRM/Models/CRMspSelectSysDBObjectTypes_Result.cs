using System;

namespace CRM.Models;

public class CRMspSelectSysDBObjectTypes_Result
{
	public int FieldDataTypeID { get; set; }

	public string DataTypeName { get; set; }

	public string DataTypeCaption { get; set; }

	public string DataTypeRegEx { get; set; }

	public int? OrderView { get; set; }

	public int LanguageID { get; set; }

	public string AppType { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }
}
