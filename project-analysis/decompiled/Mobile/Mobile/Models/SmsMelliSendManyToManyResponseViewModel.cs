namespace Mobile.Models;

public class SmsMelliSendManyToManyResponseViewModel
{
	public long? errCode { get; set; }

	public string[] result { get; set; }

	public long? msgId { get; set; }
}
