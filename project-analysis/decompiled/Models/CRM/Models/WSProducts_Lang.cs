using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProducts_LangMetadata))]
public class WSProducts_Lang
{
	public int WSProductsLangID { get; set; }

	public int ProductID { get; set; }

	public int LanguageID { get; set; }

	public string PrdName { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public string PrdDescription { get; set; }

	public string PrdModel { get; set; }

	public string PrdSHPTitle { get; set; }

	public string PrdSHPModel { get; set; }

	public string PrdSHPDescription { get; set; }

	public string PrdSHPDescriptionII { get; set; }

	public string PrdManufacturerName { get; set; }

	public string PrdNickname { get; set; }

	public string PrdAutoCalcPordItemDesc { get; set; }

	public string PrdAutoCalcPordPrjPostFix { get; set; }

	public string PrdAutoCalcPordCnvsDesc { get; set; }

	public string PrdOrdIssuePrjPostFix { get; set; }

	public string PrdValidityControlFODeActivePrjTitleGroupDesc { get; set; }

	public string PrdLocation { get; set; }

	public string PrdSeoTitle { get; set; }

	public string PrdSeoDescription { get; set; }

	public string PrdSeoAuthor { get; set; }

	public string PrdSeoCopyright { get; set; }

	public string PrdSeoKeywords { get; set; }

	public string PrdSeoFAQ { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProducts WSProducts { get; set; }
}
