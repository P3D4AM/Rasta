using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderPaymentsMetadata))]
public class WSBuyOrderPayments
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

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? bordpayDocDateTime { get; set; }

	public Guid? GUId { get; set; }

	public decimal? bordpayDocAmount { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

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

	public string bordpayAccountNumber { get; set; }

	public DateTime? bordpayLinkAccFirstTransferDate { get; set; }

	public DateTime? bordpayLinkAccLastTransferDate { get; set; }

	public string bordpayLinkAccHeaderIdStr { get; set; }

	public string bordpayLinkAccDetailIdStr { get; set; }

	public string bordpayLinkAccVoucherIdStr { get; set; }

	public decimal? bordpayAmountTemp { get; set; }

	public string bordpayDocDateTemp { get; set; }

	public DateTime? bordpayDocDateTimeTemp { get; set; }

	public string bordpayLinkAccData { get; set; }

	public int? bordpayHeadingUpDay { get; set; }

	public decimal? bordpayHeadingUpAmount { get; set; }

	public bool? bordpayIsVerified { get; set; }

	public int? bordpayVerifierId { get; set; }

	public DateTime? bordpayVerifiedRegisterDate { get; set; }

	public string bordpayVerifiedRegisterDatePersian { get; set; }

	public int? bordpayCId { get; set; }

	public int? bordpayDeActiveUserId { get; set; }

	public DateTime? bordpayDeActiveDate { get; set; }

	public string bordpayDeActiveDatePersian { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrder WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrderPayments_Lang> WSBuyOrderPayments_Lang { get; set; }

	public virtual WSBuyOrderPaymentTypes WSBuyOrderPaymentTypes { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public WSBuyOrderPayments()
	{
		WSBuyOrderPayments_Lang = (ICollection<WSBuyOrderPayments_Lang>)new HashSet<WSBuyOrderPayments_Lang>();
	}
}
