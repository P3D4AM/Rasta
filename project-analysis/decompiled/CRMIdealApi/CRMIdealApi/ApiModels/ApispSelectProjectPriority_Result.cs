using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProjectPriority_Result
{
	public int ApiProjectPriorityID { get; set; }

	public string ApiPriority { get; set; }

	public string ApiColor { get; set; }

	public string ApiPriorityDesc { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
