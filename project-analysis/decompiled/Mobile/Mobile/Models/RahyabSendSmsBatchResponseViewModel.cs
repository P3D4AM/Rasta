using System.Collections.Generic;

namespace Mobile.Models;

public class RahyabSendSmsBatchResponseViewModel
{
	public List<RahyabSendSmsBatchInfoResponseViewModel> submitResponse { get; set; }

	public string batchId { get; set; }
}
