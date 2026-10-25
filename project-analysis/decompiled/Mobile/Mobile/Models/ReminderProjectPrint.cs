namespace Mobile.Models;

public class ReminderProjectPrint
{
	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public int PrjcnvsStatusGroupId { get; set; }

	public bool PrjIsFinished { get; set; }

	public int PfCId { get; set; }

	public int? Ln { get; set; }
}
