using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmInternalMessageTreeType_LangMetadata))]
public class CrmInternalMessageTreeType_Lang
{
	public int CrmInternalMessageTreeTypeLangID { get; set; }

	public int InternalMessageTreeTypeID { get; set; }

	public int LanguageID { get; set; }

	public string MessageTreeType { get; set; }

	public virtual CrmInternalMessageTreeType CrmInternalMessageTreeType { get; set; }

	public virtual Languages Languages { get; set; }
}
