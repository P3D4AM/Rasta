using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmLinkedType_LangMetadata))]
public class CrmLinkedType_Lang
{
	public int CrmLinkedTypeLangID { get; set; }

	public int LinkedTypeID { get; set; }

	public int LanguageID { get; set; }

	public string LinkTypeName { get; set; }

	public virtual CrmLinkedType CrmLinkedType { get; set; }

	public virtual Languages Languages { get; set; }
}
