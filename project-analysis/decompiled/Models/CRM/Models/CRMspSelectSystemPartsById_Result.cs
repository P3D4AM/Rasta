using System;

namespace CRM.Models;

public class CRMspSelectSystemPartsById_Result
{
	public int SystemPartId { get; set; }

	public string PartTitle { get; set; }

	public string Part { get; set; }

	public string Type { get; set; }

	public int FirstRegisterUserId { get; set; }

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

	public bool? DeActive { get; set; }

	public string EditUser { get; set; }

	public string FirstRegisterUser { get; set; }
}
