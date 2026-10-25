using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderPaymentGroupsIIMetadata))]
public class WSOrderPaymentGroupsII
{
	public int OrderPaymentGroupIIId { get; set; }

	public string ordpayGroupIIName { get; set; }

	public string ordpayGroupIICode { get; set; }

	public string ordpayGroupIILinkAccData { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsII_Lang> WSOrderPaymentGroupsII_Lang { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSOrderPaymentTypes> WSOrderPaymentTypes { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSOrderPaymentGroupsII()
	{
		WSOrderPaymentGroupsII_Lang = (ICollection<WSOrderPaymentGroupsII_Lang>)new HashSet<WSOrderPaymentGroupsII_Lang>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPaymentTypes = (ICollection<WSOrderPaymentTypes>)new HashSet<WSOrderPaymentTypes>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
	}
}
