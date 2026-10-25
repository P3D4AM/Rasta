namespace CRM.Models;

public class CRMspSelectUsersByPositionId_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string FullName { get; set; }

	public string PersCode { get; set; }

	public int? PositionId { get; set; }
}
