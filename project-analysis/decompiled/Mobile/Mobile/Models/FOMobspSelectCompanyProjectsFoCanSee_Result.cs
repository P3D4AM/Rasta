using System;

namespace Mobile.Models;

public class FOMobspSelectCompanyProjectsFoCanSee_Result
{
	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string CompanyName { get; set; }

	public string prjTitle { get; set; }

	public string prjPostFix { get; set; }

	public string ProjectTitle { get; set; }

	public bool? prjFOCmpCanInsCnvs { get; set; }

	public bool? prjFOCmpCanNotInsCnvs { get; set; }

	public int? ProjectPercent { get; set; }

	public string LastCnvsStatus { get; set; }

	public string prjRemindDate { get; set; }

	public DateTime? prjRemindDateTime { get; set; }
}
