using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertSettlementTypeViewModel : PublicParametersWithOutCenter
{
	public int? ApiCode { get; set; }

	public string ApiName { get; set; }

	public string ApiDescription { get; set; }

	public int? ApiOrderView { get; set; }

	public string ApiLinkAccSettlementTypeIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
