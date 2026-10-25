using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductPriceMetadata))]
public class WSProductPrice
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

	public string LinkAccPrdPriceIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public decimal? PrePaymentPrice { get; set; }

	public decimal? TaxIndex { get; set; }

	public int? CId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSProductPrice_Lang> WSProductPrice_Lang { get; set; }

	public virtual WSProductPriceGroup WSProductPriceGroup { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductPrice()
	{
		WSProductPrice_Lang = (ICollection<WSProductPrice_Lang>)new HashSet<WSProductPrice_Lang>();
	}
}
