using System.Collections.Generic;

namespace CRM.Models;

public class ParmisSmsGetMessageResponseViewModel
{
	public ParmisSmsGetMessageBaseResponseViewModel MyBase { get; set; }

	public List<ParmisSmsGetMessageInfoResponseViewModel> Data { get; set; }
}
