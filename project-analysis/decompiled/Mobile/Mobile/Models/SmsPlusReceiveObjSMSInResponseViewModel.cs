using System;

namespace Mobile.Models;

public class SmsPlusReceiveObjSMSInResponseViewModel
{
	public long? Id { get; set; }

	public string Mobile { get; set; }

	public string Text { get; set; }

	public DateTime? DateTime { get; set; }
}
