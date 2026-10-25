namespace CRM.Models;

public class CurrentPayRollUserCycleViewModel
{
	public PayRollspSelectUserCycle_Result PayRoll { get; set; }

	public int PayRollCurrentId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public PayRollspReturnUserCycleFinalAmount_Result CycleFinalAmount { get; set; }
}
