namespace Mobile.Models;

public class SmsPlusSendResponseViewModel
{
	public SmsPlusErrorViewModel Error { get; set; }

	public long[] ServerIDs { get; set; }
}
