namespace Mobile.Models;

public class ISmsGetReceiveResponseViewModel
{
	public long? code { get; set; }

	public string message { get; set; }

	public string srcaddress { get; set; }

	public string receivedtime { get; set; }

	public string msgbody { get; set; }
}
