using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFilesDirectory_LangMetadata))]
public class CrmFilesDirectory_Lang
{
	public int CrmFilesDirectoryLanID { get; set; }

	public int FileDirectoryID { get; set; }

	public int LanguageID { get; set; }

	public string Title { get; set; }

	public string FileDesc { get; set; }

	public virtual CrmFilesDirectory CrmFilesDirectory { get; set; }

	public virtual Languages Languages { get; set; }
}
