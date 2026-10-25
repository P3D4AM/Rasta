using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertBuyOrderOprViewModel : PublicParametersWithOutCenter
{
	public string ApiName { get; set; }

	public int ApiOprType { get; set; }

	public int? ApiOrderView { get; set; }

	public string ApiLinkAccBuyOrderOprIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }

	public int? ApiDocOprId { get; set; }
}
