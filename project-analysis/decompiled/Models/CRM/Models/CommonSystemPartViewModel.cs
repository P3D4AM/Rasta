namespace CRM.Models;

public class CommonSystemPartViewModel
{
	public string Id { get; set; }

	public string Name { get; set; }

	public string Caption { get; set; }

	public bool Selected { get; set; }

	public bool Enabled { get; set; }

	public CommonSystemPartViewModel Group { get; set; }
}
