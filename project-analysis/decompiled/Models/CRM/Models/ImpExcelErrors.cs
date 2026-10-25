namespace CRM.Models;

public class ImpExcelErrors
{
	public int Row { get; set; }

	public int Col { get; set; }

	public string ColName { get; set; }

	public string Data { get; set; }

	public string Reason { get; set; }
}
