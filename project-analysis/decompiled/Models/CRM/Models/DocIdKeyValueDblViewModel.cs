namespace CRM.Models;

public class DocIdKeyValueDblViewModel
{
	public int Id { get; set; }

	public int Type { get; set; }

	public string Tag { get; set; }

	public double Value { get; set; }

	public bool? IsUsed { get; set; }
}
