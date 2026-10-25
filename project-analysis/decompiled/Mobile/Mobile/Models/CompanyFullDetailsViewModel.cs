using System.Collections.Generic;

namespace Mobile.Models;

public class CompanyFullDetailsViewModel
{
	public mct_MobspSelectCompanyWithID_Result Company { get; set; }

	public List<MobspSelectPersonList_Result> CompanyPersonList { get; set; }

	public List<MobspSelectProjectsList_Result> ProjectList { get; set; }

	public List<MobspSelectFilesDirectory_Result> FileList { get; set; }

	public CompanyAccountingSummaryViewModel Financial { get; set; }
}
