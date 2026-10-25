using System;

namespace CRM.Models;

public class CrmFilesDirectoryTemplateTypeMetadata
{
	public int CrmFilesDirectoryTemplateTypeID { get; set; }

	public string FilesDirectoryTemplateType { get; set; }

	public string AppType { get; set; }

	public Guid? GUId { get; set; }
}
