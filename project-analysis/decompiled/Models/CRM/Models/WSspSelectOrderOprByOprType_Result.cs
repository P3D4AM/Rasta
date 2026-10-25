using System;

namespace CRM.Models;

public class WSspSelectOrderOprByOprType_Result
{
	public int OrderOprID { get; set; }

	public string Name { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public int? DocOprId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string LinkAccOrderOprIdStr { get; set; }

	public long? DailyCounter { get; set; }

	public int? TspInty { get; set; }

	public int? TspInp { get; set; }

	public int? TspIns { get; set; }

	public bool? VerifyAfterIssue { get; set; }

	public int? TspIntyI { get; set; }

	public int? TspInpI { get; set; }

	public int? TspInsI { get; set; }

	public bool? Taxable { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }
}
