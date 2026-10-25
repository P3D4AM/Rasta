using System.Collections.Generic;

namespace Mobile.Models;

public class FoPrintLogListViewModel
{
	public long? LastRowNumber { get; set; }

	public int? LastPrintLogId { get; set; }

	public bool? LoadMore { get; set; }

	public List<FoPrintLogViewModel> ListPrintLog { get; set; }
}
