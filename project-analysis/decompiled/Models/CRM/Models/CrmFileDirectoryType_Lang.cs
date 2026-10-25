using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFileDirectoryType_LangMetadata))]
public class CrmFileDirectoryType_Lang
{
	public int CrmFileDirectoryTypeLangID { get; set; }

	public int FileDirectoryTypeID { get; set; }

	public int LanguageID { get; set; }

	public string FileDirectoryType { get; set; }

	public virtual CrmFileDirectoryType CrmFileDirectoryType { get; set; }

	public virtual Languages Languages { get; set; }
}
