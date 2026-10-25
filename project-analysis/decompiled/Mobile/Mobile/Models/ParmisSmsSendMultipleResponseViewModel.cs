using System.Collections.Generic;

namespace Mobile.Models;

public class ParmisSmsSendMultipleResponseViewModel
{
	public string ReqStatus { get; set; }

	public string Message { get; set; }

	public List<ParmisSmsSendMultipleResponseResultViewModel> Result { get; set; }
}
