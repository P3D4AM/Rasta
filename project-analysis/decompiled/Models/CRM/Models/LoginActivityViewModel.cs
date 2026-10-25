using System;

namespace CRM.Models;

public class LoginActivityViewModel
{
	public int Id { get; set; }

	public string FullName { get; set; }

	public DateTime LastActivityDateTime { get; set; }

	public string LastActivityDateTimePersian { get; set; }

	public Guid CurrGuid { get; set; }
}
