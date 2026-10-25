using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductUnits_LangMetadata))]
public class WSProductUnits_Lang
{
	public int WSProductUnitsLangID { get; set; }

	public int ProductUnitID { get; set; }

	public int LanguageID { get; set; }

	public string Unit { get; set; }

	public string Description { get; set; }

	public string UnitEn { get; set; }

	public string SHPUnit { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductUnits WSProductUnits { get; set; }
}
