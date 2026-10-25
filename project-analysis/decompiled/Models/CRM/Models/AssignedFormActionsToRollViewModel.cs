namespace CRM.Models;

public class AssignedFormActionsToRollViewModel
{
	public int ID { get; set; }

	public int FormId { get; set; }

	public string ActionPersianName { get; set; }

	public string ActionName { get; set; }

	public bool IsCheck { get; set; }
}
