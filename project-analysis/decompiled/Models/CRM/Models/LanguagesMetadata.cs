using System;

namespace CRM.Models;

public class LanguagesMetadata
{
	public int LanguageID { get; set; }

	public string LanguageName { get; set; }

	public string LanguageCollation { get; set; }

	public string LanguageDirection { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
