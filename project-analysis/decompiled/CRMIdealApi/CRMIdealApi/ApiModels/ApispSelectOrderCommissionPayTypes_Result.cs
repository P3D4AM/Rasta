using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrderCommissionPayTypes_Result
{
	public int ApiOrderCommissionPayTypeId { get; set; }

	public string ApiCommPayTypeTitle { get; set; }

	public string ApiCommPayTypeDescription { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }
}
