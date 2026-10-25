using System;

namespace CRMIdealApi.ApiModels;

public class UpdateProductCostViewModel : PublicParameters
{
	public int? ApiProductCostID { get; set; }

	public int? ApiProductId { get; set; }

	public string ApiProductCode { get; set; }

	public string ApiDocNumber { get; set; }

	public DateTime? ApiDocDateTime { get; set; }

	public decimal? ApiCost { get; set; }

	public decimal? ApiCurrencyCost { get; set; }

	public int? ApiCurrencyUnitId { get; set; }

	public decimal? ApiTransportCost { get; set; }

	public decimal? ApiReleasingCost { get; set; }

	public decimal? ApiSlagCost { get; set; }

	public decimal? ApiOtherCost { get; set; }

	public int? ApiWHId { get; set; }

	public int? ApiProductCostGroupId { get; set; }

	public string ApiDescription { get; set; }
}
