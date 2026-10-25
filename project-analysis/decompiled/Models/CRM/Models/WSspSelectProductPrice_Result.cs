using System;

namespace CRM.Models;

public class WSspSelectProductPrice_Result
{
	public int PrdPriceID { get; set; }

	public int PrdId { get; set; }

	public string DocDate { get; set; }

	public string DocNumber { get; set; }

	public decimal Price { get; set; }

	public decimal? CurrencyPrice { get; set; }

	public int? CurrencyUnitId { get; set; }

	public decimal? CooperationPrice { get; set; }

	public decimal? PricePercent { get; set; }

	public decimal? DiscountPrecent { get; set; }

	public decimal? Discount { get; set; }

	public decimal? OtherPrice { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? WHId { get; set; }

	public Guid? GUId { get; set; }

	public int? ProductPriceGroupId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime? DocDateTime { get; set; }
}
