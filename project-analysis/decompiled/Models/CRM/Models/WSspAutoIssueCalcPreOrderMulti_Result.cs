using System;

namespace CRM.Models;

public class WSspAutoIssueCalcPreOrderMulti_Result
{
	public int PreOrderID { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public int? pordCompanyId { get; set; }

	public string CompanyName { get; set; }

	public int? pordCompanyPersonId { get; set; }

	public string CompanyPersonName { get; set; }

	public int? pordProjectId { get; set; }

	public string ProjectTitle { get; set; }

	public decimal? pordTotalAmount { get; set; }

	public int? pordReferUserId { get; set; }

	public string pordReferUser { get; set; }

	public int? PreOrderOprID { get; set; }

	public string PreOrderOpr { get; set; }

	public int? pordTypeId { get; set; }

	public string pordType { get; set; }

	public int? pordCurrencyUnitId { get; set; }

	public string pordCurrencyUnit { get; set; }

	public bool? pordCurrencyUnitIsDecimal { get; set; }

	public int? PrdAutoCalcPordCnvsReferUser { get; set; }
}
