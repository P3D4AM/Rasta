using System;

namespace CRM.Models;

public class CRMspSelectImportExcelFieldGroups_Result
{
	public int Id { get; set; }

	public int SystemPartId { get; set; }

	public string SystemPart { get; set; }

	public int? GroupNum { get; set; }

	public string GroupCaption { get; set; }

	public string GroupColor { get; set; }

	public string GroupDesc { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public string AppType { get; set; }

	public int? RegisterUserId { get; set; }

	public string EditUser { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
