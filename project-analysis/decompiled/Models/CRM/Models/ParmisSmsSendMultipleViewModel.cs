namespace CRM.Models;

public class ParmisSmsSendMultipleViewModel
{
	public string username { get; set; }

	public string password { get; set; }

	public string[] to { get; set; }

	public string[] text { get; set; }

	public string from { get; set; }

	public string fromSupportOne { get; set; }

	public string fromSupportTwo { get; set; }
}
