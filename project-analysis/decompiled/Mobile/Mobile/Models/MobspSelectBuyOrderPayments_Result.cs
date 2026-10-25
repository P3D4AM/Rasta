using System;

namespace Mobile.Models;

public class MobspSelectBuyOrderPayments_Result
{
	public int BuyOrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int bordpayTypeId { get; set; }

	public int bordpayOrderId { get; set; }

	public int bordpayDocId { get; set; }

	public int bordpayDocTypeId { get; set; }

	public decimal bordpayAmount { get; set; }

	public string bordpayDocNumber { get; set; }

	public string bordpayDocDate { get; set; }

	public string bordpayDescription { get; set; }

	public int bordpayFirstRegisterUserId { get; set; }

	public string bordpayFirstRegisteDatePersian { get; set; }

	public DateTime? bordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? bordpayDocDateTime { get; set; }

	public string AppType { get; set; }

	public decimal bordpayDocAmount { get; set; }

	public int LanguageID { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string bordpayType { get; set; }

	public string RegisterUser { get; set; }

	public string FirstRegisterUser { get; set; }
}
