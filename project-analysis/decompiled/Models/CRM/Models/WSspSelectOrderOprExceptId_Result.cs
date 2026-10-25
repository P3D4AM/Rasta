using System;

namespace CRM.Models;

public class WSspSelectOrderOprExceptId_Result
{
	public int OrderOprID { get; set; }

	public string Name { get; set; }

	public Guid? GUId { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public int? DocOprId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string LinkAccOrderOprIdStr { get; set; }

	public string DocOpr { get; set; }
}
