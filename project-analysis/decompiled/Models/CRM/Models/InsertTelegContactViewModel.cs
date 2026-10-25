using System;

namespace CRM.Models;

public class InsertTelegContactViewModel
{
	public long ChatId { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string UserName { get; set; }

	public string PhoneNumber { get; set; }

	public string Type { get; set; }

	public string Title { get; set; }

	public byte[] Picture { get; set; }

	public bool IsActive { get; set; }

	public string AppType { get; set; }

	public int LanguageId { get; set; }

	public int UserId { get; set; }

	public int? UnReadMessageCount { get; set; }

	public DateTime? LastMessageDate { get; set; }

	public int SettingId { get; set; }
}
