using System;

namespace CRM.Models;

public class WSspSelectOrderOprExceptTspCmp_Result
{
	public int OrderOprExceptTspCmpId { get; set; }

	public int OrderOprId { get; set; }

	public string OrderOpr { get; set; }

	public int CompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? TspInty { get; set; }

	public int? TspInp { get; set; }

	public int? TspIns { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string TspIntyTitle { get; set; }

	public string TspInpTitle { get; set; }

	public string TspInsTitle { get; set; }
}
