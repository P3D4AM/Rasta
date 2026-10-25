namespace CRM.Models;

public class SamanBankGetTokenViewModel
{
	public int? status { get; set; }

	public long? errorCode { get; set; }

	public string errorDesc { get; set; }

	public string token { get; set; }
}
