namespace CRM.Models;

public class PayRollListUserPaymentsLanguageViewModel
{
	public int PayRollListId { get; set; }

	public int PayTypeId { get; set; }

	public decimal AmountPercent { get; set; }

	public string PaymentNumber { get; set; }

	public string PaymentDate { get; set; }

	public string Description { get; set; }

	public int BankingAccountType { get; set; }

	public string Description_Lang { get; set; }
}
