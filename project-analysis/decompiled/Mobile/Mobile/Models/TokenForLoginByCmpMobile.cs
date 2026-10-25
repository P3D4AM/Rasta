namespace Mobile.Models;

public class TokenForLoginByCmpMobile
{
	public int CompanyId { get; set; }

	public int PersonId { get; set; }

	public string AuthenticationCode { get; set; }

	public string CurrentDateTime { get; set; }
}
