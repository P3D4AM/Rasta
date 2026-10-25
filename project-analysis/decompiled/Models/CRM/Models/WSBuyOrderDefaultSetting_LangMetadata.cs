using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSBuyOrderDefaultSetting_LangMetadata
{
	[Key]
	public int WSBuyOrderDefaultSettingLangID { get; set; }

	public int BuyOrderDefaultSettingId { get; set; }

	public int LanguageID { get; set; }

	public string SettingTitle { get; set; }

	public string Title { get; set; }

	public string Subject { get; set; }

	public string Note { get; set; }

	public string DeliveryTerm { get; set; }
}
