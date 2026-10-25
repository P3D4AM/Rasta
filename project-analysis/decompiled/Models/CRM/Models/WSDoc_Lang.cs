using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSDoc_LangMetadata))]
public class WSDoc_Lang
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

	public virtual Languages Languages { get; set; }

	public virtual WSDoc WSDoc { get; set; }
}
