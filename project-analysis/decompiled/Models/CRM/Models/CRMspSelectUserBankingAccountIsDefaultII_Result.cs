using System;

namespace CRM.Models;

public class CRMspSelectUserBankingAccountIsDefaultII_Result
{
	public int BankingAccountID { get; set; }

	public int BranchId { get; set; }

	public string BranchName { get; set; }

	public int? MasterId { get; set; }

	public int AccTypeId { get; set; }

	public string AccountTypeName { get; set; }

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

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CrmUserId { get; set; }

	public int? BankId { get; set; }

	public string BankName { get; set; }

	public string AccountTitle { get; set; }

	public string AccountShabaNumber { get; set; }

	public string AccountCardNumber { get; set; }

	public string AccountDesc { get; set; }

	public bool? IsDefault { get; set; }

	public bool? IsDefaultII { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string CrmUser { get; set; }
}
