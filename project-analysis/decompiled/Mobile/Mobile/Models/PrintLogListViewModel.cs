using System.Collections.Generic;

namespace Mobile.Models;

public class PrintLogListViewModel
{
	public long? LastRowNumber { get; set; }

	public int? LastPrintLogId { get; set; }

	public bool? LoadMore { get; set; }

	public List<PrintLogViewModel> ListPrintLog { get; set; }
}
