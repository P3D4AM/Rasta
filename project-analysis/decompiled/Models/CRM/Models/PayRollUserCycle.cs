using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollUserCycleMetadata))]
public class PayRollUserCycle
{
	public int PayRollUserCycleId { get; set; }

	public int CrmUserId { get; set; }

	public string CycleTitle { get; set; }

	public int? CycleDuration { get; set; }

	public DateTime CycleDate { get; set; }

	public string CycleDatePersian { get; set; }

	public bool? CycleIsVerified { get; set; }

	public int? CycleVerifierUserId { get; set; }

	public DateTime? CycleVerifiedDate { get; set; }

	public string CycleVerifiedDatePersian { get; set; }

	public int? CyclePrintFormatId { get; set; }

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

	public decimal? CycleNetSalary { get; set; }

	public int? CycleDefBankingAccountId { get; set; }

	public int? CycleMonth { get; set; }

	public int? CycleYear { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<PayRollUserCycle_Lang> PayRollUserCycle_Lang { get; set; }

	public virtual PrintFormat PrintFormat { get; set; }

	public virtual ICollection<PayRollUserCycleItemValues> PayRollUserCycleItemValues { get; set; }

	public virtual ICollection<PayRollUserPayments> PayRollUserPayments { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions { get; set; }

	public virtual ICollection<PayRollListItems> PayRollListItems { get; set; }

	public virtual CrmBankingAccounts CrmBankingAccounts { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public PayRollUserCycle()
	{
		PayRollUserCycle_Lang = (ICollection<PayRollUserCycle_Lang>)new HashSet<PayRollUserCycle_Lang>();
		PayRollUserCycleItemValues = (ICollection<PayRollUserCycleItemValues>)new HashSet<PayRollUserCycleItemValues>();
		PayRollUserPayments = (ICollection<PayRollUserPayments>)new HashSet<PayRollUserPayments>();
		WSPreOrderCommissions = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		PayRollListItems = (ICollection<PayRollListItems>)new HashSet<PayRollListItems>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
	}
}
