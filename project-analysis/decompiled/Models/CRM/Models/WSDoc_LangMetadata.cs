namespace CRM.Models;

public class WSDoc_LangMetadata
{
	public int WSDocLangID { get; set; }

	public int DocID { get; set; }

	public int LanguageID { get; set; }

	public string SenderName { get; set; }

	public string Description { get; set; }

	public string SendAddress { get; set; }

	public string DriverName { get; set; }

	public string FreightName { get; set; }

	public string cmpTitle { get; set; }
}
