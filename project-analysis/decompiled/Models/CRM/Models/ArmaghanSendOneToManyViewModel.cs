namespace CRM.Models;

public class ArmaghanSendOneToManyViewModel
{
	public string username { get; set; }

	public string password { get; set; }

	public string originator { get; set; }

	public string content { get; set; }

	public string[] destinations { get; set; }
}
