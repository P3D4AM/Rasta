using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyMultiGroups_Result
{
	public int ApiCompanyID { get; set; }

	public string ApiCompany { get; set; }

	public int ApiCompanyGroupsMultiID { get; set; }

	public string ApiCompanyGroupsMulti { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiEditUser { get; set; }
}
