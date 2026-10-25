namespace Mobile.Models;

public class SmsPlusGetStatusResponseViewModel
{
	public SmsPlusErrorViewModel Error { get; set; }

	public int[] StatusList { get; set; }
}
