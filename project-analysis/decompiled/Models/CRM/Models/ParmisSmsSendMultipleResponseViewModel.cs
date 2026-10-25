using System.Collections.Generic;

namespace CRM.Models;

public class ParmisSmsSendMultipleResponseViewModel
{
	public string ReqStatus { get; set; }

	public string Message { get; set; }

	public List<ParmisSmsSendMultipleResponseResultViewModel> Result { get; set; }
}
