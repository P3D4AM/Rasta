using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderPaymentsMetadata))]
public class WSPreOrderPayments
{
	public int PreOrderPaymentId { get; set; }

	public string ImportDate { get; set; }

	public int pordpayTypeId { get; set; }

	public int pordpayPreOrderId { get; set; }

	public int? pordpayDocId { get; set; }

	public int? pordpayDocTypeId { get; set; }

	public decimal pordpayAmount { get; set; }

	public string pordpayDocNumber { get; set; }

	public string pordpayDocDate { get; set; }

	public decimal? pordpayDocAmount { get; set; }

	public string pordpayDescription { get; set; }

	public int? pordpayFirstRegisterUserId { get; set; }

	public string pordpayFirstRegisteDatePersian { get; set; }

	public DateTime? pordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? pordpayDocDateTime { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? pordpayLinkAccHeaderId { get; set; }

	public string pordpayLinkAccHeaderNumber { get; set; }

	public int? pordpayLinkAccDetailId { get; set; }

	public int? pordpayLinkAccVoucherId { get; set; }

	public string pordpayLinkAccVoucherNumber { get; set; }

	public string pordpayLinkAccHeaderIdStr { get; set; }

	public string pordpayLinkAccDetailIdStr { get; set; }

	public string pordpayLinkAccVoucherIdStr { get; set; }

	public int? pordpayCompanyMoneyBagId { get; set; }

	public bool? pordpayDeActive { get; set; }

	public decimal? pordpayAmountTemp { get; set; }

	public bool? pordpayIsVerified { get; set; }

	public int? pordpayVerifierId { get; set; }

	public DateTime? pordpayVerifiedRegisterDate { get; set; }

	public string pordpayVerifiedRegisterDatePersian { get; set; }

	public string pordpayFileTypeJson { get; set; }

	public string pordpayLinkAccPayType { get; set; }

	public string pordpayAccountNumber { get; set; }

	public DateTime? pordpayLinkAccFirstTransferDate { get; set; }

	public DateTime? pordpayLinkAccLastTransferDate { get; set; }

	public string pordpayDocDateTemp { get; set; }

	public DateTime? pordpayDocDateTimeTemp { get; set; }

	public string pordpayLinkAccData { get; set; }

	public int? pordpayCId { get; set; }

	public int? pordpayBankingBankID { get; set; }

	public int? pordpayBankingBranchID { get; set; }

	public int? pordpayBankingAccountID { get; set; }

	public int? pordpayCashId { get; set; }

	public int? pordpayGroupIdI { get; set; }

	public int? pordpayGroupIdII { get; set; }

	public string pordpayChqSayadNumber { get; set; }

	public string pordpayChqSerialNumber { get; set; }

	public int? pordpayDocDayTemp { get; set; }

	public string pordpayBankName { get; set; }

	public string pordpayBranchName { get; set; }

	public string pordpayBranchCode { get; set; }

	public int? pordpayDeActiveUserId { get; set; }

	public DateTime? pordpayDeActiveDate { get; set; }

	public string pordpayDeActiveDatePersian { get; set; }

	public virtual CrmCompanyMoneyBag CrmCompanyMoneyBag { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSPreOrderPayments_Lang> WSPreOrderPayments_Lang { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual WSOrderPaymentTypes WSOrderPaymentTypes { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmBankingAccounts CrmBankingAccounts { get; set; }

	public virtual CrmBankingBanks CrmBankingBanks { get; set; }

	public virtual CrmBankingBranches CrmBankingBranches { get; set; }

	public virtual CrmCashes CrmCashes { get; set; }

	public virtual WSOrderPaymentGroupsI WSOrderPaymentGroupsI { get; set; }

	public virtual WSOrderPaymentGroupsII WSOrderPaymentGroupsII { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual Users Users4 { get; set; }

	public WSPreOrderPayments()
	{
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSPreOrderPayments_Lang = (ICollection<WSPreOrderPayments_Lang>)new HashSet<WSPreOrderPayments_Lang>();
	}
}
