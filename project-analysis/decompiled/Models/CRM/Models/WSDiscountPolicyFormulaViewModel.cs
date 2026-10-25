namespace CRM.Models;

public class WSDiscountPolicyFormulaViewModel
{
	public int FVType { get; set; }

	public string FVals { get; set; }

	public decimal? FVal { get; set; }

	public decimal? TVal { get; set; }

	public int? Day { get; set; }

	public string FDate { get; set; }

	public string TDate { get; set; }

	public string Opr { get; set; }
}
