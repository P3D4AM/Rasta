using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectSex_Result
{
	public int ApiSexID { get; set; }

	public string ApiSexType { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
