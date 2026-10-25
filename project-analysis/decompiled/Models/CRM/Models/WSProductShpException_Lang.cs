using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSProductShpException_LangMetadata))]
public class WSProductShpException_Lang
{
	public int ProductShpExceptionLangID { get; set; }

	public int ProductShpExceptionId { get; set; }

	public string PrdShpExTitle { get; set; }

	public string PrdShpExCode { get; set; }

	public string PrdShpExModel { get; set; }

	public string PrdShpExDescription { get; set; }

	public string PrdShpExDescriptionII { get; set; }

	public int LanguageID { get; set; }

	public string PrdShpExSeoTitle { get; set; }

	public string PrdShpExSeoDescription { get; set; }

	public string PrdShpExSeoAuthor { get; set; }

	public string PrdShpExSeoCopyright { get; set; }

	public string PrdShpExSeoKeywords { get; set; }

	public string PrdShpExSeoFAQ { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSProductShpException WSProductShpException { get; set; }
}
