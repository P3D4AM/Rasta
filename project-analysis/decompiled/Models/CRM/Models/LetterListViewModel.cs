namespace CRM.Models;

public class LetterListViewModel
{
	public int currentId { get; set; }

	public int companyId { get; set; }

	public int ltType { get; set; }

	public string fromDate { get; set; }

	public string toDate { get; set; }

	public int? userId { get; set; }

	public int? letterId { get; set; }
}
