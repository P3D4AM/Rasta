using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateBuyOrderOprViewModel : PublicParametersWithOutCenter
{
	public int ApiBuyOrderOprId { get; set; }

	public string ApiName { get; set; }

	public int? ApiOprType { get; set; }

	public int? ApiOrderView { get; set; }

	public string ApiLinkAccBuyOrderOprIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public string ApiLinkAccData { get; set; }

	public int? ApiDocOprId { get; set; }
}
