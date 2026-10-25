using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyGroupsWithAccLinkField_Result
{
	public int CompanyGroupID { get; set; }

	public string GroupName { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public double? ScoreRate { get; set; }

	public string LinkAccGroupIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }
}
