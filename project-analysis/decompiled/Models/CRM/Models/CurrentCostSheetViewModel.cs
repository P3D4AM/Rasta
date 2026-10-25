namespace CRM.Models;

public class CurrentCostSheetViewModel
{
	public WSspSelectCostSheetsById_Result Costsheet { get; set; }

	public WSspReturnCostSheetSumFooter_Result Footer { get; set; }

	public int CtshCurrentId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }
}
