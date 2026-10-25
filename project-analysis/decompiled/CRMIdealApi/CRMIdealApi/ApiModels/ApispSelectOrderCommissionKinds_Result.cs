using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrderCommissionKinds_Result
{
	public int ApiOrderCommissionKindId { get; set; }

	public string ApiCommKindTitle { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }
}
