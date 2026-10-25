using System;

namespace CRM.Models;

public class CRMspSelectOnlinePayBankInfo_Result
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

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? BankingBankID { get; set; }

	public string BankingBank { get; set; }

	public string BankLoginPassword { get; set; }

	public string BankTerminalCode { get; set; }

	public string BankAcceptorCode { get; set; }

	public string BankSignKey { get; set; }

	public int? BankOrdPayTypeId { get; set; }

	public int? BankPordPayTypeId { get; set; }

	public int? BankOnlinePayType { get; set; }
}
