using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductCostGroup_Result
{
	public int ApiProductCostGroupID { get; set; }

	public string ApiProductCostGroupName { get; set; }

	public string ApiProductCostGroupDesc { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }
}
