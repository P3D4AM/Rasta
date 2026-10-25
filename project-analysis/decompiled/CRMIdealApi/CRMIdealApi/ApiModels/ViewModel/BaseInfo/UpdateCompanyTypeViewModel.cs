using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateCompanyTypeViewModel : PublicParametersWithOutCenter
{
	public int ApiCompanyTypeId { get; set; }

	public string ApiCompanyTypeName { get; set; }

	public int? ApiOrderView { get; set; }

	public string ApiLinkAccCmpTypeIdStr { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }

	public string ApiLinkAccData { get; set; }
}
