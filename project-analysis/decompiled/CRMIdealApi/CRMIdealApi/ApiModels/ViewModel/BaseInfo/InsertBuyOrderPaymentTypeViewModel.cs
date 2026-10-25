using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertBuyOrderPaymentTypeViewModel : PublicParametersWithOutCenter
{
	public string ApiBordpayType { get; set; }

	public string ApiBordpayTypeDescription { get; set; }

	public int? ApiOrderView { get; set; }

	public string LinkAccBordPayTypeIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }
}
