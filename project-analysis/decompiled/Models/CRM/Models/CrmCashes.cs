using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCashesMetadata))]
public class CrmCashes
{
	public int CashId { get; set; }

	public string CashTitle { get; set; }

	public string CashCode { get; set; }

	public string CashLinkAccData { get; set; }

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

	public virtual ICollection<CrmCashes_Lang> CrmCashes_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSOrderPaymentTypes> WSOrderPaymentTypes { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmCashes()
	{
		CrmCashes_Lang = (ICollection<CrmCashes_Lang>)new HashSet<CrmCashes_Lang>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPaymentTypes = (ICollection<WSOrderPaymentTypes>)new HashSet<WSOrderPaymentTypes>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
	}
}
