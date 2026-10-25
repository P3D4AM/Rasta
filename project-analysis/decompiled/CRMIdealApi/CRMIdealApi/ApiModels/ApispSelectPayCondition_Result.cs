using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectPayCondition_Result
{
	public int ApiPayConditionID { get; set; }

	public string ApiPayCondition { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
