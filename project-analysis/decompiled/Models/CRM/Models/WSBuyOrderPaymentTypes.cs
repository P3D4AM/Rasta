using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderPaymentTypesMetadata))]
public class WSBuyOrderPaymentTypes
{
	public int BuyOrderPaymentTypeId { get; set; }

	public string bordpayType { get; set; }

	public string bordpayTypeDescription { get; set; }

	public int UserId { get; set; }

	public int? FPId { get; set; }

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

	public string LinkAccBordPayTypeIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments { get; set; }

	public virtual ICollection<WSBuyOrderPaymentTypes_Lang> WSBuyOrderPaymentTypes_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSBuyOrderPaymentTypes()
	{
		WSBuyOrderPayments = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSBuyOrderPaymentTypes_Lang = (ICollection<WSBuyOrderPaymentTypes_Lang>)new HashSet<WSBuyOrderPaymentTypes_Lang>();
	}
}
