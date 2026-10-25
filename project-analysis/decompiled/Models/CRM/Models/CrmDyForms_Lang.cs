using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmDyForms_LangMetadata))]
public class CrmDyForms_Lang
{
	public int CrmDyFormLangID { get; set; }

	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public string FormHeader { get; set; }

	public string FormBody { get; set; }

	public string FormFooter { get; set; }

	public string UploadFileDescription { get; set; }

	public int LanguageID { get; set; }

	public virtual CrmDyForms CrmDyForms { get; set; }

	public virtual Languages Languages { get; set; }
}
