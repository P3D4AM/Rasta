namespace CRM.Models;

public class SamanBankCallBackViewModel
{
	public SamanBankVerifyInfoViewModel TransactionDetail { get; set; }

	public int? ResultCode { get; set; }

	public string ResultDescription { get; set; }

	public bool? Success { get; set; }
}
