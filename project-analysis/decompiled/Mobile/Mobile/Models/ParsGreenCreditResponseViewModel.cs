namespace Mobile.Models;

public class ParsGreenCreditResponseViewModel
{
	public decimal? Amount { get; set; }

	public bool? R_Success { get; set; }

	public long? R_Code { get; set; }

	public string R_Error { get; set; }

	public string R_Message { get; set; }
}
