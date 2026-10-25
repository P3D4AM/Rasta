using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductCost_Result
{
	public int ApiProductCostID { get; set; }

	public int ApiProductId { get; set; }

	public string ApiProductCode { get; set; }

	public DateTime? ApiDocDateTime { get; set; }

	public string ApiDocDate { get; set; }

	public string ApiDocNumber { get; set; }

	public decimal ApiCost { get; set; }

	public decimal? ApiCurrencyCost { get; set; }

	public int? ApiCurrencyUnitId { get; set; }

	public decimal? ApiTransportCost { get; set; }

	public decimal? ApiReleasingCost { get; set; }

	public decimal? ApiSlagCost { get; set; }

	public decimal? ApiOtherCost { get; set; }

	public int ApiEditUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public short ApiMonth1 { get; set; }

	public int ApiFPId { get; set; }

	public int? ApiWHId { get; set; }

	public int? ApiProductCostGroupId { get; set; }

	public string ApiAppType { get; set; }

	public int? ApiLanguageId { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }

	public string Description { get; set; }

	public string ApiProductName { get; set; }

	public string ApiCurrencyUnit { get; set; }

	public string ApiEditUser { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiWH { get; set; }

	public string ApiCenterName { get; set; }

	public int? CenterId { get; set; }
}
