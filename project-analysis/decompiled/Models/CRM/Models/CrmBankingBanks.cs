using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmBankingBanksMetadata))]
public class CrmBankingBanks
{
	public int BankingBankID { get; set; }

	public string Code { get; set; }

	public string BankName { get; set; }

	public string BankDesc { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string BankLinkAccData { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmBankingBranches> CrmBankingBranches { get; set; }

	public virtual ICollection<CrmOnlinePayBankInfo> CrmOnlinePayBankInfo { get; set; }

	public virtual ICollection<CrmBankingBanks_Lang> CrmBankingBanks_Lang { get; set; }

	public virtual ICollection<CrmBankingAccounts> CrmBankingAccounts { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSOrderPaymentTypes> WSOrderPaymentTypes { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmBankingBanks()
	{
		CrmBankingBranches = (ICollection<CrmBankingBranches>)new HashSet<CrmBankingBranches>();
		CrmOnlinePayBankInfo = (ICollection<CrmOnlinePayBankInfo>)new HashSet<CrmOnlinePayBankInfo>();
		CrmBankingBanks_Lang = (ICollection<CrmBankingBanks_Lang>)new HashSet<CrmBankingBanks_Lang>();
		CrmBankingAccounts = (ICollection<CrmBankingAccounts>)new HashSet<CrmBankingAccounts>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPaymentTypes = (ICollection<WSOrderPaymentTypes>)new HashSet<WSOrderPaymentTypes>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
	}
}
