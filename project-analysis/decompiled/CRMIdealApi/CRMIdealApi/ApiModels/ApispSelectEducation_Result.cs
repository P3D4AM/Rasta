using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectEducation_Result
{
	public int ApiEducationID { get; set; }

	public string ApiEducation { get; set; }

	public int? ApiUserId { get; set; }

	public DateTime? ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
