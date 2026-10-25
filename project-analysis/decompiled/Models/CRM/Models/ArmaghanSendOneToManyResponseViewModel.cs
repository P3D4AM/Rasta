namespace CRM.Models;

public class ArmaghanSendOneToManyResponseViewModel
{
	public ArmaghanErrorResponseViewModel errorModel { get; set; }

	public long[] references { get; set; }
}
