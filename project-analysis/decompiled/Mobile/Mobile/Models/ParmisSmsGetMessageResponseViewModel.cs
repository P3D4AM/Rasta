using System.Collections.Generic;

namespace Mobile.Models;

public class ParmisSmsGetMessageResponseViewModel
{
	public ParmisSmsGetMessageBaseResponseViewModel MyBase { get; set; }

	public List<ParmisSmsGetMessageInfoResponseViewModel> Data { get; set; }
}
