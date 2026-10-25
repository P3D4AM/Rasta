using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyGroup_Result
{
	public int ApiCompanyGroupID { get; set; }

	public string ApiGroupName { get; set; }

	public string ApiGroupDesc { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
