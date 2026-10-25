using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class EmailDefaultBodyText_LangMetadata
{
	[Key]
	public int EmailDefaultBodyTextLangID { get; set; }

	public int EmailDefaultBodyTextId { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }

	public string Body { get; set; }
}
