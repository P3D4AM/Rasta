namespace CRM.Models;

public class LKCrmBankingAccountsViewModel
{
	public int DBId { get; set; }

	public string AccountTitle { get; set; }

	public string LinkAccIdStr { get; set; }

	public string LinkAccCode { get; set; }

	public string AccountNumber { get; set; }

	public string BranchName { get; set; }

	public string LinkAccBrchIdStr { get; set; }

	public string LinkAccBrchCode { get; set; }

	public string BankName { get; set; }

	public string LinkAccBnkIdStr { get; set; }

	public string LinkAccBnkCode { get; set; }
}
