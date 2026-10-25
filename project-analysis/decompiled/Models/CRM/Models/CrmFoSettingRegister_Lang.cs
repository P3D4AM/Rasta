using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmFoSettingRegister_LangMetadata))]
public class CrmFoSettingRegister_Lang
{
	public int CrmFoSettingRegisterLangID { get; set; }

	public int FoSettingRegisterId { get; set; }

	public int LanguageID { get; set; }

	public string PrjDefaultTitle { get; set; }

	public string PrjDefaultPostFix { get; set; }

	public string CnvsDefaultDesc { get; set; }

	public string CnvsDefaultReferDesc { get; set; }

	public virtual CrmFoSettingRegister CrmFoSettingRegister { get; set; }

	public virtual Languages Languages { get; set; }
}
