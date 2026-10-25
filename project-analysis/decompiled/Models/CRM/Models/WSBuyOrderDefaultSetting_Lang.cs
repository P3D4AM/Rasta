using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSBuyOrderDefaultSetting_LangMetadata))]
public class WSBuyOrderDefaultSetting_Lang
{
	public int WSBuyOrderDefaultSettingLangID { get; set; }

	public int BuyOrderDefaultSettingId { get; set; }

	public int LanguageID { get; set; }

	public string SettingTitle { get; set; }

	public string Title { get; set; }

	public string Subject { get; set; }

	public string Note { get; set; }

	public string DeliveryTerm { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSBuyOrderDefaultSetting WSBuyOrderDefaultSetting { get; set; }
}
