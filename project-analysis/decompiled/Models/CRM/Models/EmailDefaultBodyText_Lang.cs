using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(EmailDefaultBodyText_LangMetadata))]
public class EmailDefaultBodyText_Lang
{
	public int EmailDefaultBodyTextLangID { get; set; }

	public int EmailDefaultBodyTextId { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }

	public string Body { get; set; }

	public virtual EmailDefaultBodyText EmailDefaultBodyText { get; set; }

	public virtual Languages Languages { get; set; }
}
