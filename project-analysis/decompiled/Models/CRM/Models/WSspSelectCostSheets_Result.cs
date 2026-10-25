using System;

namespace CRM.Models;

public class WSspSelectCostSheets_Result
{
	public int CostSheetId { get; set; }

	public int? prjCompanyId { get; set; }

	public string prjCompany { get; set; }

	public int? prjCompanyNumber { get; set; }

	public int? ctshCmpProjectId { get; set; }

	public string ctshCmpProject { get; set; }

	public int? PreOrderId { get; set; }

	public string PreOrderInfo { get; set; }

	public long ctshNumber { get; set; }

	public DateTime ctshDate { get; set; }

	public string ctshDatePersian { get; set; }

	public string ctshTitle { get; set; }

	public int ctshSrcCurrencyUnitId { get; set; }

	public string ctshSrcCurrencyUnit { get; set; }

	public int ctshDestCurrencyUnitId { get; set; }

	public string ctshDestCurrencyUnit { get; set; }

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

	public string ctshVerifier { get; set; }

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

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string ctshNumRef { get; set; }

	public string pordNumRef { get; set; }

	public string prjNumRef { get; set; }

	public decimal? ctshMarkupSum { get; set; }

	public string ctshMarkupSumFormula { get; set; }
}
