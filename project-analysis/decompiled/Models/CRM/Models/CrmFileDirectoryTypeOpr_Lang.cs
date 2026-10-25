using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFileDirectoryTypeOpr_LangMetadata))]
public class CrmFileDirectoryTypeOpr_Lang
{
	public int CrmFileDirectoryTypeOprLangID { get; set; }

	public int FileDirectoryTypeOprId { get; set; }

	public int LanguageID { get; set; }

	public string FileDirectoryTypeOpr { get; set; }

	public virtual CrmFileDirectoryTypeOpr CrmFileDirectoryTypeOpr { get; set; }

	public virtual Languages Languages { get; set; }
}
