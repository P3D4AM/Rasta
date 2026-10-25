using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderDefaultSetting_LangMetadata))]
public class WSOrderDefaultSetting_Lang
{
	public int WSOrderDefaultSettingLangID { get; set; }

	public int OrderSettingID { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }

	public string Subject { get; set; }

	public string SpecialWord { get; set; }

	public string DescriptionI { get; set; }

	public string DescriptionII { get; set; }

	public string SettingTitle { get; set; }

	public string SigningI { get; set; }

	public string SigningII { get; set; }

	public string SigningIII { get; set; }

	public string Note { get; set; }

	public string DefAutoAddCnvsDesc { get; set; }

	public string AddPrdValidityPrjTitle { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderDefaultSetting WSOrderDefaultSetting { get; set; }
}
