using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductColor_Result
{
	public int ApiProductColorID { get; set; }

	public string ApiColor { get; set; }

	public string ApiColorDescription { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiColorEn { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }

	public string ApiColorCode { get; set; }
}
