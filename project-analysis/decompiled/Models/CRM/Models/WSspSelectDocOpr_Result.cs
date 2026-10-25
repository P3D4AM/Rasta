using System;

namespace CRM.Models;

public class WSspSelectDocOpr_Result
{
	public int DocOprID { get; set; }

	public string Name { get; set; }

	public Guid? GUId { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public int? UserId { get; set; }

	public string EditUser { get; set; }

	public int? FPId { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
