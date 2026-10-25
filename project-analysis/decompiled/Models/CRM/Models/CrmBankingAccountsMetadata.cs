using System;

namespace CRM.Models;

public class CrmBankingAccountsMetadata
{
	public int BankingAccountID { get; set; }

	public int BranchId { get; set; }

	public int MasterId { get; set; }

	public int AccTypeId { get; set; }

	public string AccountNumber { get; set; }

	public string AccountType { get; set; }

	public string AccountOwner { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
