using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectPersonType_Result
{
	public int ApiPersonTypeID { get; set; }

	public string ApiPersonType { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
