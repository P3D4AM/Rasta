using System;

namespace CRM.Models;

public class CrmBankingBranchesMetadata
{
	public int BankingBranchID { get; set; }

	public int? BankId { get; set; }

	public string BranchName { get; set; }

	public string BranchCode { get; set; }

	public string BranchAddress { get; set; }

	public string BranchTel { get; set; }

	public string BranchTelII { get; set; }

	public string BranchDesc { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
