using System;

namespace CRM.Models;

public class SharifResponseTokenViewModel
{
	public string Token { get; set; }

	public DateTime? Expiration { get; set; }
}
