using System;

namespace CRMIdealApi.ApiModels;

public class SelectStockSupplyViewModel : PublicParameters
{
	public int? ApiStockSupplyId { get; set; }

	public long? ApiStockSupplyNumber { get; set; }

	public int? ApiCompanyId { get; set; }

	public DateTime? ApiFromDate { get; set; }

	public DateTime? ApiToDate { get; set; }
}
