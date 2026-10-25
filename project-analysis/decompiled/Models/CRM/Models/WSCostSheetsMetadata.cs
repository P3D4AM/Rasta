using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSCostSheetsMetadata
{
	[Key]
	public int CostSheetId { get; set; }

	public int? PreOrderId { get; set; }

	public long ctshNumber { get; set; }

	public DateTime ctshDate { get; set; }

	public string ctshDatePersian { get; set; }

	public string ctshTitle { get; set; }

	public int ctshSrcCurrencyUnitId { get; set; }

	public int ctshDestCurrencyUnitId { get; set; }

	public double ctshCurrencyRate { get; set; }

	public double ctshRoundRate { get; set; }

	public decimal? ctshSumAmount { get; set; }

	public decimal? ctshTaxIndex { get; set; }

	public decimal? ctshTax { get; set; }

	public decimal? ctshTotalAmount { get; set; }

	public double? ctshMarkup { get; set; }

	public string ctshMarkupFormula { get; set; }

	public bool? ctshIsVerified { get; set; }

	public int? ctshVerifierId { get; set; }

	public DateTime? ctshVerifiedDate { get; set; }

	public string ctshVerifiedDatePersian { get; set; }

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

	public int? ctshCmpProjectId { get; set; }
}
