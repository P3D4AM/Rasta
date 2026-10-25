using System.Collections.Generic;

namespace CRM.Models;

public class SeriesDataColorViewModel<T>
{
	public string name { get; set; }

	public string color { get; set; }

	public ICollection<T> data { get; set; }
}
