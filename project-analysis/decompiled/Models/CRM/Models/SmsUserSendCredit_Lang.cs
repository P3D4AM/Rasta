using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(SmsUserSendCredit_LangMetadata))]
public class SmsUserSendCredit_Lang
{
	public int SmsUserSendCreditLangID { get; set; }

	public int ID { get; set; }

	public int LanguageID { get; set; }

	public string Description { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual SmsUserSendCredit SmsUserSendCredit { get; set; }
}
