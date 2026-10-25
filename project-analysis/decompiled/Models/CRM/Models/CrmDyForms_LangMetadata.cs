using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmDyForms_LangMetadata
{
	[Key]
	public int CrmDyFormLangID { get; set; }

	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public string FormHeader { get; set; }

	public string FormBody { get; set; }

	public string FormFooter { get; set; }

	public int LanguageID { get; set; }
}
