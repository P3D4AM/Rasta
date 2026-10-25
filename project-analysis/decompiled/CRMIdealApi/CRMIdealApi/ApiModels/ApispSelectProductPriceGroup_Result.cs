using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductPriceGroup_Result
{
	public int ApiProductPriceGroupID { get; set; }

	public string ApiProductPriceGroupName { get; set; }

	public string ApiProductPriceGroupDesc { get; set; }

	public bool? ApiSHPDefaultPriceGroup { get; set; }

	public bool? ApiSHPPriceGroupVisible { get; set; }

	public int? ApiOrderView { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }
}
