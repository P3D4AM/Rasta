namespace CRM.Models;

public class KaramadTokenResponseViewModel
{
	public string error { get; set; }

	public string error_description { get; set; }

	public string access_token { get; set; }

	public string refresh_token { get; set; }
}
