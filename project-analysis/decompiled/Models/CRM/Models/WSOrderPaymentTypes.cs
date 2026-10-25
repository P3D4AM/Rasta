using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderPaymentTypesMetadata))]
public class WSOrderPaymentTypes
{
	public int OrderPaymentTypeId { get; set; }

	public string ordpayType { get; set; }

	public string ordpayTypeDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string LinkAccOrdPayTypeIdStr { get; set; }

	public bool? DeActive { get; set; }

	public bool? ordpayTypeIsActivePayOnline { get; set; }

	public bool? ordpayTypeIsActiveAddFile { get; set; }

	public string ordpayTypePordFileTypeJson { get; set; }

	public string ordpayTypeOrdFileTypeJson { get; set; }

	public bool? ordpayTypeIsChq { get; set; }

	public string TspOrdpayTypeIinn { get; set; }

	public string TspOrdpayTypeAcn { get; set; }

	public string TspOrdpayTypeTrmn { get; set; }

	public int? TspOrdpayTypePmt { get; set; }

	public bool? ordPayTypeIsPos { get; set; }

	public string ordPayTypePosTerminal { get; set; }

	public string ordPayTypePosUserName { get; set; }

	public string ordPayTypePosPassword { get; set; }

	public string ordPayTypePosURL { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public int? ordpayTypeBankingBankID { get; set; }

	public int? ordpayTypeBankingBranchID { get; set; }

	public int? ordpayTypeBankingAccountID { get; set; }

	public int? ordpayTypeCashId { get; set; }

	public int? ordpayTypeGroupIdI { get; set; }

	public int? ordpayTypeGroupIdII { get; set; }

	public int? ordpayTypeKind { get; set; }

	public int? ordpayTypeMode { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSOrderPaymentTypes_Lang> WSOrderPaymentTypes_Lang { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual ICollection<CrmOnlinePayBankInfo> CrmOnlinePayBankInfo { get; set; }

	public virtual ICollection<CrmOnlinePayBankInfo> CrmOnlinePayBankInfo1 { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual CrmBankingAccounts CrmBankingAccounts { get; set; }

	public virtual CrmBankingBanks CrmBankingBanks { get; set; }

	public virtual CrmBankingBranches CrmBankingBranches { get; set; }

	public virtual CrmCashes CrmCashes { get; set; }

	public virtual WSOrderPaymentGroupsI WSOrderPaymentGroupsI { get; set; }

	public virtual WSOrderPaymentGroupsII WSOrderPaymentGroupsII { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSOrderPaymentTypes()
	{
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPaymentTypes_Lang = (ICollection<WSOrderPaymentTypes_Lang>)new HashSet<WSOrderPaymentTypes_Lang>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		CrmOnlinePayBankInfo = (ICollection<CrmOnlinePayBankInfo>)new HashSet<CrmOnlinePayBankInfo>();
		CrmOnlinePayBankInfo1 = (ICollection<CrmOnlinePayBankInfo>)new HashSet<CrmOnlinePayBankInfo>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
