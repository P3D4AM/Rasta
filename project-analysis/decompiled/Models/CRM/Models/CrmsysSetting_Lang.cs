using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmsysSetting_LangMetadata))]
public class CrmsysSetting_Lang
{
	public int CrmsysSettingLangID { get; set; }

	public int ID { get; set; }

	public string CoName { get; set; }

	public string Address { get; set; }

	public string PublicNotice { get; set; }

	public string QuickAddress { get; set; }

	public int LanguageID { get; set; }

	public string MuBuySaleWhTitle { get; set; }

	public string SaleOrderLbl { get; set; }

	public string SaleReturnOrderLbl { get; set; }

	public string PrjPostFixTooltip { get; set; }

	public string DyFormCartablesLbl { get; set; }

	public string SendSMSOrdFOLinkAfterVerifyBodyPatternFormula { get; set; }

	public string CoNameMobApp { get; set; }

	public string CoNameMobHRMApp { get; set; }

	public string SendSMSPordFOLinkAfterVerifyBodyPatternFormula { get; set; }

	public string CoLocations { get; set; }

	public virtual CrmsysSetting CrmsysSetting { get; set; }

	public virtual Languages Languages { get; set; }
}
