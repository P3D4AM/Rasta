using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCurrencyUnitRateMetadata))]
public class WSCurrencyUnitRate
{
	public int CurrencyUnitRateId { get; set; }

	public int SrcCurrencyUnitId { get; set; }

	public int DestCurrencyUnitId { get; set; }

	public double CurrencyRate { get; set; }

	public DateTime RateDate { get; set; }

	public string RateDatePersian { get; set; }

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

	public virtual Languages Languages { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits1 { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }
}
