using System;

namespace CRM.Models;

public class WSspCalcCompanyPrdIndexPrice_Result
{
	public int? PrdId { get; set; }

	public string PrdName { get; set; }

	public decimal? CalculatedFinalAmount { get; set; }

	public string DetailCalcInfoJs { get; set; }

	public int? IndexOrderId { get; set; }

	public string ErrorMessage { get; set; }

	public DateTime? ordIValidityExpireDate { get; set; }

	public DateTime? pordExpireDateTime { get; set; }
}
