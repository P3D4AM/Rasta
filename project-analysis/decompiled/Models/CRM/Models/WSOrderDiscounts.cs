using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderDiscountsMetadata))]
public class WSOrderDiscounts
{
	public int OrderDiscountId { get; set; }

	public int ordDisOrderId { get; set; }

	public int ordDisDiscountStrategyId { get; set; }

	public string ordDisTitle { get; set; }

	public decimal? ordDisAmount { get; set; }

	public decimal? ordDisPercent { get; set; }

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

	public int? ordDisPrdId { get; set; }

	public int? ordDisCId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSDiscountStrategy WSDiscountStrategy { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSOrderDiscounts_Lang> WSOrderDiscounts_Lang { get; set; }

	public virtual WSOrder WSOrder { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSOrderDiscounts()
	{
		WSOrderDiscounts_Lang = (ICollection<WSOrderDiscounts_Lang>)new HashSet<WSOrderDiscounts_Lang>();
	}
}
