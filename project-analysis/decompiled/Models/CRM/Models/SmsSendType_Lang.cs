using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsSendType_LangMetadata))]
public class SmsSendType_Lang
{
	public int SmsSendTypeLangID { get; set; }

	public int ID { get; set; }

	public int LanguageID { get; set; }

	public string SMSSendType { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SmsSendType SmsSendType1 { get; set; }
}
