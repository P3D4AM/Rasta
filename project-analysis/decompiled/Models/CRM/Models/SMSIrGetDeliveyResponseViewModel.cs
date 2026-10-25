namespace CRM.Models;

public class SMSIrGetDeliveyResponseViewModel
{
	public int status { get; set; }

	public string message { get; set; }

	public SMSIrGetDeliveyDataResponseViewModel data { get; set; }
}
