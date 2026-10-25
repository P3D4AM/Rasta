using System;

namespace Mobile.Models;

public class MobspReturnProductUserDiscountValue_Result
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

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
