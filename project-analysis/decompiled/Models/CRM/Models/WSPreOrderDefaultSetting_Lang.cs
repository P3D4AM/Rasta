using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderDefaultSetting_LangMetadata))]
public class WSPreOrderDefaultSetting_Lang
{
	public int WSPreOrderDefaultSettingLangID { get; set; }

	public int PreOrderSettingID { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }

	public string Subject { get; set; }

	public string SpecialWord { get; set; }

	public string DescriptionI { get; set; }

	public string DescriptionII { get; set; }

	public string SigningI { get; set; }

	public string SigningII { get; set; }

	public string SigningIII { get; set; }

	public string Address { get; set; }

	public string SettingTitle { get; set; }

	public string DefAutoAddCnvsDesc { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSPreOrderDefaultSetting WSPreOrderDefaultSetting { get; set; }
}
