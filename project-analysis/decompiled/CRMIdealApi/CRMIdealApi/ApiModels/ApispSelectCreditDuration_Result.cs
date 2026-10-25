using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCreditDuration_Result
{
	public int ApiCreditDurationID { get; set; }

	public string ApiCreditDuration { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }

	public int? ApiCreditDurationHours { get; set; }
}
