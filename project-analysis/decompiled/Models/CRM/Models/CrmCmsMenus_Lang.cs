using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmCmsMenus_LangMetadata))]
public class CrmCmsMenus_Lang
{
	public int CrmCmsMenuLangID { get; set; }

	public int MenuId { get; set; }

	public int LanguageID { get; set; }

	public string MenuTitle { get; set; }

	public virtual CrmCmsMenus CrmCmsMenus { get; set; }

	public virtual Languages Languages { get; set; }
}
