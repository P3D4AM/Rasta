using System;

namespace CRM.Models;

public class CRMspSelectsysDBObjectsNotNull_Result
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
}
