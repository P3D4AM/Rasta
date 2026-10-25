namespace CRM.Models;

public class WSspCheckDuplicateDocItemTracing_Result
{
	public int DocItemID { get; set; }

	public int DocId { get; set; }

	public int? docNumber { get; set; }

	public int PrdId { get; set; }

	public string PrdName { get; set; }
}
