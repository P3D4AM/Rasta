namespace CRM.Models;

public class CrmCompanyQuickRegisterDefSettingForCnvsLanguageViewModel
{
	public int CompanyQuickRegisterDefSettingId { get; set; }

	public string SettingTitle { get; set; }

	public int? cnvsTopicId { get; set; }

	public string cnvsDesc { get; set; }

	public string cnvsReferDesc { get; set; }

	public int? cnvsStatusId { get; set; }

	public int? cnvsPriorityId { get; set; }

	public int? cnvsRemindDateIncDay { get; set; }

	public string cnvsRemindDate { get; set; }

	public string cnvsRemindTime { get; set; }

	public int? cnvsRemindDateForAllarmIncDay { get; set; }

	public string cnvsRemindDateForAllarm { get; set; }

	public bool? cnvsFOCmpCanSee { get; set; }

	public bool? IsDefault { get; set; }

	public string SettingTitle_Lang { get; set; }

	public string cnvsDesc_Lang { get; set; }

	public string cnvsReferDesc_Lang { get; set; }
}
