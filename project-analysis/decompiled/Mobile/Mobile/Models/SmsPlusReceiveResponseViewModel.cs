using System.Collections.Generic;

namespace Mobile.Models;

public class SmsPlusReceiveResponseViewModel
{
	public SmsPlusErrorViewModel Error { get; set; }

	public List<SmsPlusReceiveObjSMSInResponseViewModel> SMSReceived { get; set; }
}
