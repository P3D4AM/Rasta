using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderStatusMetadata))]
public class WSOrderStatus
{
	public int OrderStatusId { get; set; }

	public string OrderStatus { get; set; }

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

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSOrderStatus_Lang> WSOrderStatus_Lang { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSOrderStatus()
	{
		WSOrderStatus_Lang = (ICollection<WSOrderStatus_Lang>)new HashSet<WSOrderStatus_Lang>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
	}
}
