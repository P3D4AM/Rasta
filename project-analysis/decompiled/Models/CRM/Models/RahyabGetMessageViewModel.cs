using System;

namespace CRM.Models;

public class RahyabGetMessageViewModel
{
	public long? id { get; set; }

	public string mobile_number { get; set; }

	public string source_number { get; set; }

	public string message { get; set; }

	public string status { get; set; }

	public string message_status { get; set; }

	public DateTime? date { get; set; }

	public DateTime? end_time { get; set; }

	public DateTime? creation_date { get; set; }

	public string dcs { get; set; }

	public string dest_port { get; set; }

	public string source_port { get; set; }

	public bool? isRead { get; set; }

	public string userName { get; set; }

	public long? count { get; set; }
}
