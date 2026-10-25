using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsFiles_LangMetadata))]
public class CrmCmsFiles_Lang
{
	public int CrmCmsFileLangID { get; set; }

	public int FileId { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }

	public virtual CrmCmsFiles CrmCmsFiles { get; set; }

	public virtual Languages Languages { get; set; }
}
