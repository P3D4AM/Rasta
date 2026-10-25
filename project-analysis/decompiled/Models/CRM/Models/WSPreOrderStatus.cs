using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderStatusMetadata))]
public class WSPreOrderStatus
{
	public int PreOrderStatusId { get; set; }

	public string PreOrderStatus { get; set; }

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

	public virtual ICollection<WSPreOrderStatus_Lang> WSPreOrderStatus_Lang { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSPreOrderStatus()
	{
		WSPreOrderStatus_Lang = (ICollection<WSPreOrderStatus_Lang>)new HashSet<WSPreOrderStatus_Lang>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
	}
}
