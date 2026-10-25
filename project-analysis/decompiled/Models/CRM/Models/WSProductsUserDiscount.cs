using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductsUserDiscountMetadata))]
public class WSProductsUserDiscount
{
	public int ProductsUserDiscountId { get; set; }

	public string ProductsUserDiscountDate { get; set; }

	public DateTime ProductsUserDiscountDateTime { get; set; }

	public int ProductGroupId { get; set; }

	public int? DiscountUserId { get; set; }

	public bool? DiscountAllUser { get; set; }

	public int? DiscountProductId { get; set; }

	public bool? DiscountAllPrdInGroup { get; set; }

	public decimal DiscountPercent { get; set; }

	public string Description { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSProductSecondGroup WSProductSecondGroup { get; set; }

	public virtual ICollection<WSProductsUserDiscount_Lang> WSProductsUserDiscount_Lang { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }

	public WSProductsUserDiscount()
	{
		WSProductsUserDiscount_Lang = (ICollection<WSProductsUserDiscount_Lang>)new HashSet<WSProductsUserDiscount_Lang>();
	}
}
