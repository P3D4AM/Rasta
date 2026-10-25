namespace CRM.Models;

public class WSspIssueCompleteOrder_Result
{
	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public int? OrderId { get; set; }

	public long? OrderNumber { get; set; }

	public string ErrorIds { get; set; }

	public string ErrorJson { get; set; }
}
