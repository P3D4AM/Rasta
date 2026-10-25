using System;

namespace CRMIdealApi.ApiModels;

public class Rpt_WareHouseStockViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int ApiMode { get; set; }

	public int? ApiFPId { get; set; }

	public int? ApiWHID { get; set; }

	public int? ApiFGId { get; set; }

	public int? ApiSGId { get; set; }

	public int? ApiPrdId { get; set; }

	public double? ApiMaxStkVal { get; set; }

	public double? ApiMinStkVal { get; set; }

	public double? ApiEqualStkVal { get; set; }

	public string ApiPrdModel { get; set; }

	public string ApiTracing { get; set; }

	public DateTime? FromRegisterDate { get; set; }

	public DateTime? ToRegisterDate { get; set; }

	public int? LanguageId { get; set; }
}
