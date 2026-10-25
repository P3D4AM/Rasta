using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyGroupsIII_Result
{
	public int ApiCompanyGroupIIIID { get; set; }

	public string ApiGroupIIIName { get; set; }

	public string ApiGroupIIIDesc { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
