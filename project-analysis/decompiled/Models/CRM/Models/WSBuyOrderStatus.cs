using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderStatusMetadata))]
public class WSBuyOrderStatus
{
	public int BuyOrderStatusId { get; set; }

	public string BuyOrderStatus { get; set; }

	public int? OrderView { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrderStatus_Lang> WSBuyOrderStatus_Lang { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSBuyOrderStatus()
	{
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderStatus_Lang = (ICollection<WSBuyOrderStatus_Lang>)new HashSet<WSBuyOrderStatus_Lang>();
	}
}
