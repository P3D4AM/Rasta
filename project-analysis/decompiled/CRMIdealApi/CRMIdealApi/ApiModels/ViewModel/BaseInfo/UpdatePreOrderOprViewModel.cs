using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdatePreOrderOprViewModel : PublicParametersWithOutCenter
{
	public int ApiPreOrderOprId { get; set; }

	public string ApiPreOrderOpr { get; set; }

	public string ApiDescription { get; set; }

	public int ApiOrderView { get; set; }

	public string ApiLinkAccPreOrderOprIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public string ApiLinkAccData { get; set; }
}
