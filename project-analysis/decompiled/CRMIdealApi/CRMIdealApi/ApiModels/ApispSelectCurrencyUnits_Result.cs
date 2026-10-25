using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCurrencyUnits_Result
{
	public int ApiCurrencyUnitID { get; set; }

	public string ApiCurrencyUnit { get; set; }

	public string ApiDescription { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiCurrencyUnitEn { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
