namespace Mobile.Models.ViewModel.Sms.WebService.ISms;

public class ISmsGetStatusResponseViewModel
{
	public long? code { get; set; }

	public string message { get; set; }

	public int[] status { get; set; }
}
