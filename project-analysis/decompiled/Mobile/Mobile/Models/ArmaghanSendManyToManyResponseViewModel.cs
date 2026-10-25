namespace Mobile.Models;

public class ArmaghanSendManyToManyResponseViewModel
{
	public ArmaghanErrorResponseViewModel errorModel { get; set; }

	public long[] references { get; set; }
}
