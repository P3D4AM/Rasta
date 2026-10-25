using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSProductShpException_LangMetadata
{
	[Key]
	public int ProductShpExceptionLangID { get; set; }

	public int ProductShpExceptionId { get; set; }

	public string PrdShpExTitle { get; set; }

	public string PrdShpExCode { get; set; }

	public string PrdShpExModel { get; set; }

	public string PrdShpExDescription { get; set; }

	public string PrdShpExDescriptionII { get; set; }

	public int LanguageID { get; set; }
}
