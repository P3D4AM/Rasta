using System;

namespace CRM.Models;

public class SmsspSelectGSMNotSendItems_Result
{
	public int ID { get; set; }

	public string Number { get; set; }

	public string Body { get; set; }

	public string CompanyName { get; set; }

	public string PersonName { get; set; }

	public DateTime? SendDateTime { get; set; }
}
