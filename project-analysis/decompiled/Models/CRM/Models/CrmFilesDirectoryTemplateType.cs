using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFilesDirectoryTemplateTypeMetadata))]
public class CrmFilesDirectoryTemplateType
{
	public int CrmFilesDirectoryTemplateTypeID { get; set; }

	public string FilesDirectoryTemplateType { get; set; }

	public string AppType { get; set; }

	public Guid? GUId { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual ICollection<CrmFilesDirectoryTemplate> CrmFilesDirectoryTemplate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public CrmFilesDirectoryTemplateType()
	{
		CrmFilesDirectoryTemplate = (ICollection<CrmFilesDirectoryTemplate>)new HashSet<CrmFilesDirectoryTemplate>();
	}
}
