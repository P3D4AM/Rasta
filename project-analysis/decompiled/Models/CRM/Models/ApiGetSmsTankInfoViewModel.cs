using System;

namespace CRM.Models;

public class ApiGetSmsTankInfoViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public DateTime? FromDate { get; set; }

	public DateTime? ToDate { get; set; }

	public int? LanguageId { get; set; }
}
