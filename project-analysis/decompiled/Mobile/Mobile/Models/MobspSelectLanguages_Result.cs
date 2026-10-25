namespace Mobile.Models;

public class MobspSelectLanguages_Result
{
	public int LanguageID { get; set; }

	public string LanguageName { get; set; }

	public string LanguageCollation { get; set; }

	public string LanguageDirection { get; set; }

	public bool? IsActive { get; set; }
}
