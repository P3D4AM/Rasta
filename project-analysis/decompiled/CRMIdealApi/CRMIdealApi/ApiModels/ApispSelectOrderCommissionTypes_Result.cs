using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrderCommissionTypes_Result
{
	public int ApiOrderCommissionTypeId { get; set; }

	public string ApiCommTypeTitle { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }
}
