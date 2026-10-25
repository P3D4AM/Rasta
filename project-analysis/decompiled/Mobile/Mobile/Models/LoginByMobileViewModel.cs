namespace Mobile.Models;

public class LoginByMobileViewModel
{
	public string mobileNumber { get; set; }

	public string Company { get; set; }

	public string Persons { get; set; }

	public string Projects { get; set; }

	public string Conversations { get; set; }

	public string Type { get; set; }

	public int LangId { get; set; }

	public int? CenterId { get; set; }
}
