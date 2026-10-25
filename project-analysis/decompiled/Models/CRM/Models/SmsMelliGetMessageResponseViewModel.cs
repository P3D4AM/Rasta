using System.Collections.Generic;

namespace CRM.Models;

public class SmsMelliGetMessageResponseViewModel
{
	public long? errCode { get; set; }

	public List<SmsMelliGetMessageInfoResponseViewModel> result { get; set; }
}
