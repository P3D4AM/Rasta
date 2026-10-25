using System;

namespace CRM.Models;

public class SmsspSelectSmsReadySend_Result
{
	public int ID { get; set; }

	public string Number { get; set; }

	public string Body { get; set; }

	public string CompanyName { get; set; }

	public string PersonName { get; set; }

	public DateTime? SendDateTime { get; set; }

	public string SendDate { get; set; }

	public string SendType { get; set; }

	public int? StatusId { get; set; }

	public string DeliveryStatus { get; set; }
}
