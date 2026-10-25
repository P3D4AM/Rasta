using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsDefaultBodyText_LangMetadata))]
public class SmsDefaultBodyText_Lang
{
	public int SmsDefaultBodyTextLangID { get; set; }

	public int Id { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }

	public string Text { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SmsDefaultBodyText SmsDefaultBodyText { get; set; }
}
