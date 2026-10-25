using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmBankingAccountsMetadata))]
public class CrmBankingAccounts
{
	public int BankingAccountID { get; set; }

	public int BranchId { get; set; }

	public int? MasterId { get; set; }

	public int AccTypeId { get; set; }

	public string AccountNumber { get; set; }

	public string AccountType { get; set; }

	public string AccountOwner { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CrmUserId { get; set; }

	public int? BankId { get; set; }

	public string AccountTitle { get; set; }

	public string AccountShabaNumber { get; set; }

	public string AccountCardNumber { get; set; }

	public string AccountDesc { get; set; }

	public bool? IsDefault { get; set; }

	public bool? IsDefaultII { get; set; }

	public bool? MobHRMVisible { get; set; }

	public string AccountLinkAccData { get; set; }

	public virtual CrmBankingAccountType CrmBankingAccountType { get; set; }

	public virtual CrmBankingBanks CrmBankingBanks { get; set; }

	public virtual CrmBankingBranches CrmBankingBranches { get; set; }

	public virtual CrmCompanyPersons CrmCompanyPersons { get; set; }

	public virtual ICollection<CrmBankingAccounts_Lang> CrmBankingAccounts_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<PayRollUserCycle> PayRollUserCycle { get; set; }

	public virtual ICollection<PayRollUserPayments> PayRollUserPayments { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSOrderPaymentTypes> WSOrderPaymentTypes { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public CrmBankingAccounts()
	{
		CrmBankingAccounts_Lang = (ICollection<CrmBankingAccounts_Lang>)new HashSet<CrmBankingAccounts_Lang>();
		PayRollUserCycle = (ICollection<PayRollUserCycle>)new HashSet<PayRollUserCycle>();
		PayRollUserPayments = (ICollection<PayRollUserPayments>)new HashSet<PayRollUserPayments>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPaymentTypes = (ICollection<WSOrderPaymentTypes>)new HashSet<WSOrderPaymentTypes>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
	}
}
