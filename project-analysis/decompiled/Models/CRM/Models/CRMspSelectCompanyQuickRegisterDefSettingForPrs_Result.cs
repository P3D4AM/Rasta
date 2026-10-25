namespace CRM.Models;

public class CRMspSelectCompanyQuickRegisterDefSettingForPrs_Result
{
	public int CompanyQuickRegisterDefSettingId { get; set; }

	public string SettingTitle { get; set; }

	public int? prsTitleId { get; set; }

	public int? prsJobId { get; set; }

	public int? prsTypeId { get; set; }

	public int? prsGroupId { get; set; }

	public int? prsSexId { get; set; }

	public int? prsEducationId { get; set; }

	public int? prsCityId { get; set; }

	public string prsSpecialPoint { get; set; }

	public string prsDescription { get; set; }

	public int? prsDepartmentId { get; set; }

	public bool? IsDefault { get; set; }

	public bool? IsDefaultForCmpInfo { get; set; }

	public bool? IsDefaultForPerson { get; set; }
}
