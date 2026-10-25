namespace CRM.Models;

public class CRMspSelectUserLanguages_Result
{
	public int UserId { get; set; }

	public int LanguageID { get; set; }

	public string LanguageCollation { get; set; }

	public string LanguageName { get; set; }

	public bool IsActive { get; set; }

	public string LanguageDirection { get; set; }
}
