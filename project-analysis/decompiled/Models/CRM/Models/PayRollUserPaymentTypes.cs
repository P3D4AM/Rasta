using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollUserPaymentTypesMetadata))]
public class PayRollUserPaymentTypes
{
	public int PayRollUserPaymentTypeId { get; set; }

	public string PaymentType { get; set; }

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

	public virtual Languages Languages { get; set; }

	public virtual ICollection<PayRollUserPayments> PayRollUserPayments { get; set; }

	public virtual ICollection<PayRollUserPaymentTypes_Lang> PayRollUserPaymentTypes_Lang { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public PayRollUserPaymentTypes()
	{
		PayRollUserPayments = (ICollection<PayRollUserPayments>)new HashSet<PayRollUserPayments>();
		PayRollUserPaymentTypes_Lang = (ICollection<PayRollUserPaymentTypes_Lang>)new HashSet<PayRollUserPaymentTypes_Lang>();
	}
}
