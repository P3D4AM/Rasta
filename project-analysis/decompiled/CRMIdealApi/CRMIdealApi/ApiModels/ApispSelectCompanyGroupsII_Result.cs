using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyGroupsII_Result
{
	public int ApiCompanyGroupIIID { get; set; }

	public string ApiGroupIIName { get; set; }

	public string ApiGroupIIDesc { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
