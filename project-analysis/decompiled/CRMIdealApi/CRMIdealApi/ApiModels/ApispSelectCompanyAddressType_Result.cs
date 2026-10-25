using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyAddressType_Result
{
	public int ApiCompanyAddressTypeId { get; set; }

	public string ApiCompanyAddressTypeName { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
