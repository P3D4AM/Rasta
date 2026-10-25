using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductUnits_Result
{
	public int ApiProductUnitID { get; set; }

	public int? ApiQuantityInUnit { get; set; }

	public string ApiDescription { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiUnitEn { get; set; }

	public double? ApiFCR { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }

	public int? ApiUnitLinkAccUnitId { get; set; }

	public double? ApiFCRI { get; set; }

	public string ApiSHPUnit { get; set; }

	public string ApiUnit { get; set; }
}
