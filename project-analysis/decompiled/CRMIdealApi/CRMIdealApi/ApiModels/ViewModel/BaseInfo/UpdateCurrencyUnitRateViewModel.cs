using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCurrencyUnitRateViewModel : PublicParametersWithOutCenter
{
	public int ApiSrcCurrencyUnitId { get; set; }

	public int ApiDestCurrencyUnitId { get; set; }

	public float ApiCurrencyRate { get; set; }

	public DateTime? ApiRateDateTime { get; set; }

	public int ApiCurrencyUnitRateId { get; set; }
}
