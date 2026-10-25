using System;

namespace Mobile.Models;

public class MobspSelectOrderPaymentsWithId_Result
{
	public int OrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int ordpayTypeId { get; set; }

	public int ordpayOrderId { get; set; }

	public int? ordpayDocId { get; set; }

	public int? ordpayDocTypeId { get; set; }

	public decimal ordpayAmount { get; set; }

	public string ordpayDocNumber { get; set; }

	public string ordpayDocDate { get; set; }

	public string ordpayDescription { get; set; }

	public int? ordpayFirstRegisterUserId { get; set; }

	public string ordpayFirstRegisteDatePersian { get; set; }

	public DateTime? ordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? ordpayDocDateTime { get; set; }

	public decimal? ordpayDocAmount { get; set; }

	public int? PreOrderPaymentId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string ordpayBankDocNumber { get; set; }

	public int? ordpayCompanyMoneyBagId { get; set; }

	public bool? ordpayDeActive { get; set; }

	public decimal? ordpayAmountTemp { get; set; }

	public bool? ordpayIsVerified { get; set; }

	public int? ordpayVerifierId { get; set; }

	public DateTime? ordpayVerifiedRegisterDate { get; set; }

	public string ordpayVerifiedRegisterDatePersian { get; set; }

	public string ordpayFileTypeJson { get; set; }

	public string ordpayCardNumber { get; set; }

	public string ordpayAccountNumber { get; set; }

	public DateTime? ordpayBankDocDate { get; set; }

	public string ordpayBankDocDatePersian { get; set; }

	public decimal? ordpayBankDocAmount { get; set; }

	public string ordpayBankDocDesc { get; set; }

	public string ordpayBankDocDescI { get; set; }

	public int? ordpayBankDocRegisterUserId { get; set; }

	public DateTime? ordpayBankDocRegisterDate { get; set; }

	public string ordpayBankDocRegisterDatePersian { get; set; }

	public string ordpayType { get; set; }

	public string RegisterUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string ordpayVerifier { get; set; }

	public string ordpayFileTypeJsonByName { get; set; }

	public string ordpayBankDocRegisterUser { get; set; }

	public string ordpayBankName { get; set; }

	public string ordpayBranchCode { get; set; }

	public string ordpayBranchName { get; set; }

	public int? ordpayDeActiveUserId { get; set; }

	public string ordpayDeActiveUser { get; set; }

	public DateTime? ordpayDeActiveDate { get; set; }

	public string ordpayDeActiveDatePersian { get; set; }
}
