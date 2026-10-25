using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollUserPaymentsMetadata))]
public class PayRollUserPayments
{
	public int PayRollUserPaymentId { get; set; }

	public int CycleId { get; set; }

	public int PayTypeId { get; set; }

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

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? BankingAccountId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollUserCycle PayRollUserCycle { get; set; }

	public virtual ICollection<PayRollUserPayments_Lang> PayRollUserPayments_Lang { get; set; }

	public virtual PayRollUserPaymentTypes PayRollUserPaymentTypes { get; set; }

	public virtual CrmBankingAccounts CrmBankingAccounts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public PayRollUserPayments()
	{
		PayRollUserPayments_Lang = (ICollection<PayRollUserPayments_Lang>)new HashSet<PayRollUserPayments_Lang>();
	}
}
