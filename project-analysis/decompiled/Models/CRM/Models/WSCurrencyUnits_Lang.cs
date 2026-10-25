using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSCurrencyUnits_LangMetadata))]
public class WSCurrencyUnits_Lang
{
	public int WSCurrencyUnitsLangID { get; set; }

	public int CurrencyUnitID { get; set; }

	public int LanguageID { get; set; }

	public string CurrencyUnit { get; set; }

	public string Description { get; set; }

	public string CurrencyUnitEn { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSCurrencyUnits WSCurrencyUnits { get; set; }
}
