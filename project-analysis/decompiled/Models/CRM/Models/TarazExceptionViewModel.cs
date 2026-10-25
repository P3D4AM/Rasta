using System;
using System.Collections.Generic;

namespace CRM.Models;

public class TarazExceptionViewModel
{
	public string error { get; set; }

	public string message { get; set; }

	public int status { get; set; }

	public DateTime? timestamp { get; set; }

	public List<Dictionary<string, string>> errors { get; set; }
}
