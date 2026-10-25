using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCenterProducts_Result
{
	public int ApiCenterProductID { get; set; }

	public bool? ApiIsActive { get; set; }

	public bool? ApiShpShowAfterLogin { get; set; }

	public int? ApiCenterID { get; set; }

	public string ApiCenterName { get; set; }

	public string ApiCenterCode { get; set; }

	public int? ApiProductID { get; set; }

	public string ApiPrdName { get; set; }

	public string ApiPrdCode { get; set; }

	public string ApiEditUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }
}
