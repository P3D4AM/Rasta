namespace CRM.Models;

public class CRMspSelectOnlinePayBankInfoByName_Result
{
	public int OnlinePayBankInfoId { get; set; }

	public string BankName { get; set; }

	public int? BankCurrencyRate { get; set; }

	public string BankLoginAccount { get; set; }

	public string BankAdditionalData { get; set; }

	public string BankIPGPageUrl { get; set; }

	public string BankPGWSaleServiceUrl { get; set; }

	public string BankPGWConfirmServiceUrl { get; set; }

	public string BankReversalServiceUrl { get; set; }

	public string BankSalePaymentCallback { get; set; }

	public bool? IsActive { get; set; }

	public int? OrderView { get; set; }

	public int? BankingBankID { get; set; }

	public string BankingBank { get; set; }

	public string BankLoginPassword { get; set; }

	public string BankTerminalCode { get; set; }

	public string BankAcceptorCode { get; set; }

	public string BankSignKey { get; set; }

	public int? BankOnlinePayType { get; set; }

	public int? BankOrdPayTypeId { get; set; }

	public int? BankPordPayTypeId { get; set; }
}
