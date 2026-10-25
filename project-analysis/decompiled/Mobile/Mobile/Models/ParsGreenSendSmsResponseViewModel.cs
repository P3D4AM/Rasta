using System.Collections.Generic;

namespace Mobile.Models;

public class ParsGreenSendSmsResponseViewModel
{
	public int? SuccessCount { get; set; }

	public List<ParsGreenSendSmsDataListResponseViewModel> DataList { get; set; }

	public bool? R_Success { get; set; }

	public long? R_Code { get; set; }

	public string R_Error { get; set; }

	public string R_Message { get; set; }
}
