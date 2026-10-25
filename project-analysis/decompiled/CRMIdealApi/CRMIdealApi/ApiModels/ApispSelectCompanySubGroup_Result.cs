using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanySubGroup_Result
{
	public int ApiCompanySubGroupID { get; set; }

	public int ApiGroupId { get; set; }

	public string ApiSubGroupName { get; set; }

	public string ApiSubGroupDesc { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
