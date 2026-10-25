namespace CRM.Models;

public class CRMspSelectUsersByIdsWithPaging_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string FullName { get; set; }

	public int? TotalCount { get; set; }
}
