using System;

namespace Mobile.Models;

public class MobspSelectOrderOprById_Result
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

	public string DocOpr { get; set; }

	public string FirstRegisterUser { get; set; }

	public long? DailyCounter { get; set; }

	public int? TspInty { get; set; }

	public int? TspInp { get; set; }

	public int? TspIns { get; set; }

	public bool? VerifyAfterIssue { get; set; }

	public int? TspIntyI { get; set; }

	public int? TspInpI { get; set; }

	public int? TspInsI { get; set; }

	public bool? Taxable { get; set; }
}
