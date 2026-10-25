using System;

namespace CRM.Models;

public class WSspCostSheetIndicator_Result
{
	public int CostSheetId { get; set; }

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

	public int? ctshCmpProjectId { get; set; }

	public string ctshNumRef { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string EditUser { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string prjTitle { get; set; }

	public string prjPostFix { get; set; }

	public string prjInquiryNum { get; set; }

	public string prjNumRef { get; set; }

	public long? prjNumR { get; set; }

	public string ProjectTitle { get; set; }

	public string prjCompany { get; set; }

	public int? CompanyNumber { get; set; }

	public string CompanyCode { get; set; }

	public string CompanyProvince { get; set; }

	public string CompanyCity { get; set; }

	public string CompanyAddress { get; set; }

	public string CompanyZipCode { get; set; }

	public string CompanyTel { get; set; }

	public string CompanyTelII { get; set; }

	public string CompanyFax { get; set; }

	public int? cmpMainPersonId { get; set; }

	public string cmpMainPerson { get; set; }

	public string rptUserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public decimal? ctshMarkupSum { get; set; }

	public string ctshMarkupSumFormula { get; set; }
}
