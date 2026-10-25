using System;

namespace Mobile.Models;

public class HRMMobPayRollspSelectUserPayments_Result
{
	public int PayRollUserPaymentId { get; set; }

	public int CycleId { get; set; }

	public int PayTypeId { get; set; }

	public string PayType { get; set; }

	public decimal Amount { get; set; }

	public string UserAccountNumber { get; set; }

	public string PaymentNumber { get; set; }

	public DateTime? PaymentDate { get; set; }

	public string PaymentDatePersian { get; set; }

	public string Description { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? BankingAccountId { get; set; }

	public string BankingAccountTitle { get; set; }

	public string BankingAccountNumber { get; set; }

	public string BankingAccountShabaNumber { get; set; }

	public string BankingAccountCardNumber { get; set; }
}
