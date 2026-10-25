using System;

namespace CRM.Models;

public class WSspSelectProductsUserDiscountByPrdGroupId_Result
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

	public string ProductGroup { get; set; }

	public string Product { get; set; }

	public string DiscountUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
