using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertCurrencyUnitViewModel : PublicParametersWithOutCenter
{
	public string ApiCurrencyUnit { get; set; }

	public string ApiDescription { get; set; }

	public string ApiCurrencyUnitEn { get; set; }

	public bool? ApiIsDecimal { get; set; }

	public string ApiTspCurrencyUnitCode { get; set; }

	public string LinkAccCurrencyUnitIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
