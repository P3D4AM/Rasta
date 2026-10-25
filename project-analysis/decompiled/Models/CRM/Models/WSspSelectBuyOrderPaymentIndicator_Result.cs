using System;

namespace CRM.Models;

public class WSspSelectBuyOrderPaymentIndicator_Result
{
	public int BuyOrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int bordpayTypeId { get; set; }

	public int bordpayOrderId { get; set; }

	public int? bordpayDocId { get; set; }

	public int? bordpayDocTypeId { get; set; }

	public decimal bordpayAmount { get; set; }

	public string bordpayDocNumber { get; set; }

	public string bordpayDocDate { get; set; }

	public string bordpayDescription { get; set; }

	public int? bordpayFirstRegisterUserId { get; set; }

	public string bordpayFirstRegisteDatePersian { get; set; }

	public DateTime? bordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? bordpayDocDateTime { get; set; }

	public decimal? bordpayDocAmount { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? bordpayLinkAccHeaderId { get; set; }

	public string bordpayLinkAccHeaderNumber { get; set; }

	public int? bordpayLinkAccDetailId { get; set; }

	public int? bordpayLinkAccVoucherId { get; set; }

	public string bordpayLinkAccVoucherNumber { get; set; }

	public bool? bordpayDeActive { get; set; }

	public string bordpayLinkAccPayType { get; set; }

	public int? bordCompanyId { get; set; }

	public string bordCompany { get; set; }

	public string bordCompanyPerson { get; set; }

	public long? bordNumber { get; set; }

	public string bordDate { get; set; }

	public DateTime? bordDateTime { get; set; }

	public decimal? bordTotalAmount { get; set; }

	public int? bordReferUserId { get; set; }

	public int? BuyOrderOprId { get; set; }

	public string BuyOrderOpr { get; set; }

	public string bordpayType { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string bordReferUser { get; set; }

	public int? bordLinkAccCodeId { get; set; }

	public string bordLinkAccCode { get; set; }

	public int? bordLinkAccBuyOrderId { get; set; }

	public string bordLinkAccBuyOrderNumber { get; set; }

	public int? bordLinkAccVoucherId { get; set; }

	public string bordLinkAccVoucherNumber { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyCode { get; set; }

	public string CompanyNationalCode { get; set; }

	public string PersonNationalCode { get; set; }

	public string rptUserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public decimal? bordpayAmountTemp { get; set; }

	public string bordpayDocDateTemp { get; set; }

	public DateTime? bordpayDocDateTimeTemp { get; set; }

	public string bordpayLinkAccData { get; set; }

	public bool? bordpayIsVerified { get; set; }

	public int? bordpayVerifierId { get; set; }

	public string bordpayVerifier { get; set; }

	public DateTime? bordpayVerifiedRegisterDate { get; set; }

	public string bordpayVerifiedRegisterDatePersian { get; set; }
}
