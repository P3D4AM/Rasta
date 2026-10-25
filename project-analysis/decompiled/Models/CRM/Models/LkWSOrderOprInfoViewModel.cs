namespace CRM.Models;

public class LkWSOrderOprInfoViewModel
{
	public int OrderOprID { get; set; }

	public string Name { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public int? DocOprId { get; set; }

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

	public string LinkAccData { get; set; }
}
