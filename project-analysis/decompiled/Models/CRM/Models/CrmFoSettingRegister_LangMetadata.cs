using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmFoSettingRegister_LangMetadata
{
	[Key]
	public int CrmFoSettingRegisterLangID { get; set; }

	public int FoSettingRegisterId { get; set; }

	public int LanguageID { get; set; }

	public string PrjDefaultTitle { get; set; }

	public string PrjDefaultPostFix { get; set; }

	public string CnvsDefaultDesc { get; set; }

	public string CnvsDefaultReferDesc { get; set; }
}
