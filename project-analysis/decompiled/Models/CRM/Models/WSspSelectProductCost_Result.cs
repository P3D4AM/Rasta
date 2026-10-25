using System;

namespace CRM.Models;

public class WSspSelectProductCost_Result
{
	public int ProductCostID { get; set; }

	public int PrdId { get; set; }

	public string DocDate { get; set; }

	public DateTime? DocDateTime { get; set; }

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
}
