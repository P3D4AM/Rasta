namespace CRM.Models;

public class ArpaItemIEResponseViewModel
{
	public ArpaItemIEInfoResponseViewModel data { get; set; }

	public string error { get; set; }

	public bool? status { get; set; }
}
