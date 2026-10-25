using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyGroupsIV_Result
{
	public int ApiCompanyGroupIVID { get; set; }

	public string ApiGroupIVName { get; set; }

	public string ApiGroupIVDesc { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
