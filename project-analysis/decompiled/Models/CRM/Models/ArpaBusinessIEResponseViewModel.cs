namespace CRM.Models;

public class ArpaBusinessIEResponseViewModel
{
	public ArpaBusinessIEInfoResponseViewModel data { get; set; }

	public string error { get; set; }

	public bool? status { get; set; }
}
