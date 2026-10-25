using System.Collections.Generic;

namespace CRM.Models;

public class RahyabSendSmsLikeToLikeViewModel
{
	public List<RahyabSendSmsLikeToLikeInfoViewModel> listLikeToLikeMessage { get; set; }

	public string number { get; set; }

	public string userName { get; set; }

	public string password { get; set; }

	public string company { get; set; }
}
