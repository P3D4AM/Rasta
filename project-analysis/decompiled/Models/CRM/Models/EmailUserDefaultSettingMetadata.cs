using System;

namespace CRM.Models;

internal class EmailUserDefaultSettingMetadata
{
	public int EmailUserDefaultSettingId { get; set; }

	public string eudTitle { get; set; }

	public string eudBody { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
