using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCallType_LangMetadata))]
public class CrmCallType_Lang
{
	public int CrmCallTypeLangID { get; set; }

	public int CallTypeID { get; set; }

	public int? LanguageID { get; set; }

	public string CallType { get; set; }

	public virtual CrmCallType CrmCallType { get; set; }

	public virtual Languages Languages { get; set; }
}
