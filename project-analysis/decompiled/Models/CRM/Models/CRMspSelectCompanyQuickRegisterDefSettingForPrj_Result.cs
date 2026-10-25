namespace CRM.Models;

public class CRMspSelectCompanyQuickRegisterDefSettingForPrj_Result
{
	public int CompanyQuickRegisterDefSettingId { get; set; }

	public string SettingTitle { get; set; }

	public string prjTitle { get; set; }

	public string prjDesc { get; set; }

	public int? prjGradeId { get; set; }

	public int? prjPriorityId { get; set; }

	public int? prjGroupId { get; set; }

	public int? prjcnvsStatusGroupId { get; set; }

	public string prjPostFix { get; set; }

	public int? prjRemindDateIncDay { get; set; }

	public bool? prjFOCmpCanSee { get; set; }

	public string prjSubject { get; set; }

	public string prjTitleGroup { get; set; }

	public int? prjCategoryId { get; set; }

	public string prjDescI { get; set; }

	public bool? IsDefault { get; set; }

	public bool? IsDefaultForCmpInfo { get; set; }

	public bool? IsDefaultForProject { get; set; }
}
