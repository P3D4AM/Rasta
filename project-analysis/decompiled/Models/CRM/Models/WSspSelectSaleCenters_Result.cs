using System;

namespace CRM.Models;

public class WSspSelectSaleCenters_Result
{
	public int SaleCenterId { get; set; }

	public string SaleCenterName { get; set; }

	public string LinkAccSaleCenterIdStr { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? ParentId { get; set; }

	public string ParentName { get; set; }

	public string StartTime { get; set; }

	public string EndTime { get; set; }

	public int? ReferUserId { get; set; }

	public string ReferUser { get; set; }

	public string SaleCenterTitle { get; set; }
}
