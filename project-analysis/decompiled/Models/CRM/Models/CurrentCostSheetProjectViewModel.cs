namespace CRM.Models;

public class CurrentCostSheetProjectViewModel
{
	public WSspSelectCrmProjectsForCostSheet_Result Project { get; set; }

	public int CtshPrjCurrentId { get; set; }

	public int CtshPrjNextId { get; set; }

	public int CtshPrjPreviousId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int CtshPrjFirstId { get; set; }

	public int CtshPrjLastId { get; set; }

	public string PreOrderInfo { get; set; }

	public int? PreOrderId { get; set; }
}
