using System.Collections.Generic;

namespace Mobile.Models;

public class CandooGetMessageResponseViewModel
{
	public List<CandooGetMessageInfoResponseViewModel> inboundMessages { get; set; }

	public long? currentPage { get; set; }

	public long? totalItems { get; set; }

	public long? totalPages { get; set; }
}
