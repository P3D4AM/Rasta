using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCompanyPresentationViewModel : PublicParametersWithOutCenter
{
	public int ApiCompanyPresentationId { get; set; }

	public string ApiPresentation { get; set; }

	public string ApiLinkAccCmpPresentationIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }
}
