namespace Mobile.Models;

public class ParmisSmsSendViewModel
{
	public string username { get; set; }

	public string password { get; set; }

	public string to { get; set; }

	public string from { get; set; }

	public string text { get; set; }

	public bool isFlash { get; set; }
}
