namespace CRM.Models;

public class DraftListViewModel
{
	public int draftCurrentId { get; set; }

	public int? companyId { get; set; }

	public int? draftNumber { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public int? userId { get; set; }

	public int? draftId { get; set; }

	public int oprType { get; set; }
}
