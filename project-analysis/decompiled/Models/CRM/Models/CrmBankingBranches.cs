using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmBankingBranchesMetadata))]
public class CrmBankingBranches
{
	public int BankingBranchID { get; set; }

	public int? BankId { get; set; }

	public string BranchName { get; set; }

	public string BranchCode { get; set; }

	public string BranchAddress { get; set; }

	public string BranchTel { get; set; }

	public string BranchTelII { get; set; }

	public string BranchDesc { get; set; }

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

	public string BranchLinkAccData { get; set; }

	public virtual CrmBankingBanks CrmBankingBanks { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmBankingBranches_Lang> CrmBankingBranches_Lang { get; set; }

	public virtual ICollection<CrmBankingAccounts> CrmBankingAccounts { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSOrderPaymentTypes> WSOrderPaymentTypes { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmBankingBranches()
	{
		CrmBankingBranches_Lang = (ICollection<CrmBankingBranches_Lang>)new HashSet<CrmBankingBranches_Lang>();
		CrmBankingAccounts = (ICollection<CrmBankingAccounts>)new HashSet<CrmBankingAccounts>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPaymentTypes = (ICollection<WSOrderPaymentTypes>)new HashSet<WSOrderPaymentTypes>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
	}
}
