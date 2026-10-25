using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmCompanyQuickRegisterDefSetting_LangMetadata
{
	[Key]
	public int CrmCompanyQuickRegisterDefSettingLangID { get; set; }

	public int CompanyQuickRegisterDefSettingId { get; set; }

	public int LanguageID { get; set; }

	public string SettingTitle { get; set; }

	public string cmpActivityType { get; set; }

	public string cmpSpecialPoint { get; set; }

	public string cmpDescription { get; set; }

	public string prsSpecialPoint { get; set; }

	public string prsDescription { get; set; }

	public string prjTitle { get; set; }

	public string prjDesc { get; set; }

	public string prjPostFix { get; set; }

	public string prjSubject { get; set; }

	public string prjTitleGroup { get; set; }

	public string prjDescI { get; set; }

	public string cnvsDesc { get; set; }

	public string cnvsReferDesc { get; set; }
}
