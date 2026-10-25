using System;

namespace CRM.Models;

public class CRMspSelectSysTempData_Result
{
	public int TempDataId { get; set; }

	public int TempDataUserId { get; set; }

	public int? TempDataSysPartIdI { get; set; }

	public int? TempDataSysPartObjIdI { get; set; }

	public int? TempDataSysPartIdII { get; set; }

	public int? TempDataSysPartObjIdII { get; set; }

	public string TempDataValue { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string TempDataUser { get; set; }

	public string TempDataSysPartI { get; set; }

	public string TempDataSysPartII { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
