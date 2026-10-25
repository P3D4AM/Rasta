using System;

namespace CRM.Models;

public class WSspSelectDocOprByoprType_Result
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
}
