using System.Collections.Generic;

namespace CRM.Models;

public class SeriesDataViewModel<T>
{
	public string name { get; set; }

	public ICollection<T> data { get; set; }
}
