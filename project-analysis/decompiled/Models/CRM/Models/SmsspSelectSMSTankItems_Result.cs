using System;

namespace CRM.Models;

public class SmsspSelectSMSTankItems_Result
{
	public int ID { get; set; }

	public string Number { get; set; }

	public string Body { get; set; }

	public string CompanyName { get; set; }

	public string PersonName { get; set; }

	public DateTime? SendDateTime { get; set; }

	public string SendType { get; set; }

	public string SendDate { get; set; }

	public string SendTime { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FromNumber { get; set; }
}
