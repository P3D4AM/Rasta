using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmOperationsType_LangMetadata))]
public class CrmOperationsType_Lang
{
	public int CrmOperationsTypeLangID { get; set; }

	public int OperationsTypeID { get; set; }

	public int LanguageID { get; set; }

	public string Type { get; set; }

	public virtual CrmOperationsType CrmOperationsType { get; set; }

	public virtual Languages Languages { get; set; }
}
