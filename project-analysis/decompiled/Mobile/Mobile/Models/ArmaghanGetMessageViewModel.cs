namespace Mobile.Models;

public class ArmaghanGetMessageViewModel
{
	public string username { get; set; }

	public string password { get; set; }

	public string destination { get; set; }

	public int page { get; set; }

	public int size { get; set; }

	public long afterId { get; set; }
}
