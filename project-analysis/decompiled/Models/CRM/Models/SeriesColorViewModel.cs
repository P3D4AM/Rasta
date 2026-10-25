namespace CRM.Models;

public class SeriesColorViewModel<T>
{
	public string name { get; set; }

	public string color { get; set; }

	public T y { get; set; }
}
