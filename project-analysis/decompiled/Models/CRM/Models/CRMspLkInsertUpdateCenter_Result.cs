namespace CRM.Models;

public class CRMspLkInsertUpdateCenter_Result
{
	public string ErrorMessage { get; set; }

	public int? InsertedId { get; set; }

	public int? FoundedId { get; set; }

	public string CenterCode { get; set; }

	public int? ParentId { get; set; }

	public string ParentCode { get; set; }
}
