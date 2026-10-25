namespace Mobile.Models;

public class ArmaghanSendManyToManyViewModel
{
	public string username { get; set; }

	public string password { get; set; }

	public string originator { get; set; }

	public string[] contents { get; set; }

	public string[] destinations { get; set; }
}
