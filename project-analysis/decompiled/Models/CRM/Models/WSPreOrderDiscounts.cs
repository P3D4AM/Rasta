using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderDiscountsMetadata))]
public class WSPreOrderDiscounts
{
	public int PreOrderDiscountId { get; set; }

	public int pordDisPreOrderId { get; set; }

	public int? pordDisDiscountStrategyId { get; set; }

	public string pordDisTitle { get; set; }

	public decimal? pordDisAmount { get; set; }

	public decimal? pordDisPercent { get; set; }

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

	public int? pordDisPrdId { get; set; }

	public int? pordDisCId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDiscountStrategy WSDiscountStrategy { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrderDiscounts_Lang> WSPreOrderDiscounts_Lang { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSPreOrderDiscounts()
	{
		WSPreOrderDiscounts_Lang = (ICollection<WSPreOrderDiscounts_Lang>)new HashSet<WSPreOrderDiscounts_Lang>();
	}
}
