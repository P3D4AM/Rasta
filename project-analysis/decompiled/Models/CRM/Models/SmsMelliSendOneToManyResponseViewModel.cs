namespace CRM.Models;

public class SmsMelliSendOneToManyResponseViewModel
{
	public long? errCode { get; set; }

	public string[] result { get; set; }

	public long? msgId { get; set; }
}
