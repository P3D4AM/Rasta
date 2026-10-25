using System;

namespace CRM.Models;

public class SmsspSelectGSMNotSendItemsViewModel
{
	public int ID { get; set; }

	public string Number { get; set; }

	public string Body { get; set; }

	public string CompanyName { get; set; }

	public string PersonName { get; set; }

	public DateTime? SendDateTime { get; set; }

	public string SendDateTimeStr { get; set; }

	public string SendType { get; set; }
}
