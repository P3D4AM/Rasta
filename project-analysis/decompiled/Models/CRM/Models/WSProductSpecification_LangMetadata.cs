namespace CRM.Models;

public class WSProductSpecification_LangMetadata
{
	public int WSProductSpecificationLangID { get; set; }

	public int ProductSpecificationID { get; set; }

	public int LanguageID { get; set; }

	public string Specification { get; set; }

	public string SpecificationI { get; set; }

	public string SpecificationII { get; set; }
}
