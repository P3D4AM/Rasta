using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProjectGroups_Result
{
	public int ApiProjectGroupID { get; set; }

	public string ApiProjectGroup { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
