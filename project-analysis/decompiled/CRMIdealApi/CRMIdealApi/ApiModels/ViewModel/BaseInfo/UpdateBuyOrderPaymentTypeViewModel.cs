using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateBuyOrderPaymentTypeViewModel : PublicParametersWithOutCenter
{
	public int ApiBuyOrderPaymentTypeId { get; set; }

	public string ApiBordpayType { get; set; }

	public string ApiBordpayTypeDescription { get; set; }

	public int? ApiOrderView { get; set; }

	public string ApiLinkAccBordPayTypeIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public string ApiLinkAccData { get; set; }
}
