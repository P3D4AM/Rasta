using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductCostMetadata))]
public class WSProductCost
{
	public int ProductCostID { get; set; }

	public int PrdId { get; set; }

	public string DocDate { get; set; }

	public string DocNumber { get; set; }

	public decimal Cost { get; set; }

	public decimal? CurrencyCost { get; set; }

	public int? CurrencyUnitId { get; set; }

	public decimal? TransportCost { get; set; }

	public decimal? ReleasingCost { get; set; }

	public decimal? SlagCost { get; set; }

	public decimal? OtherCost { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? WHId { get; set; }

	public Guid? GUId { get; set; }

	public int? ProductCostGroupId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public DateTime? DocDateTime { get; set; }

	public int? CId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual ICollection<WSProductCost_Lang> WSProductCost_Lang { get; set; }

	public virtual WSProductCostGroup WSProductCostGroup { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual WSProducts WSProducts { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSProductCost()
	{
		WSProductCost_Lang = (ICollection<WSProductCost_Lang>)new HashSet<WSProductCost_Lang>();
		WSDocItems = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
	}
}
