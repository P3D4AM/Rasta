using System.Collections.Generic;

namespace Mobile.Models;

public class ArmaghanGetMessageResultResponseViewModel
{
	public long? recordsTotal { get; set; }

	public long? recordsFiltered { get; set; }

	public List<ArmaghanGetMessageInfoResponseViewModel> data { get; set; }
}
