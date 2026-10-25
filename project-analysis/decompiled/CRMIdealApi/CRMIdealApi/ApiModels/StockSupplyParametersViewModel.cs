using System;

namespace CRMIdealApi.ApiModels;

public class StockSupplyParametersViewModel : PublicParameters
{
	public int ApiStsupReferUserId { get; set; }

	public long ApiStsupNumber { get; set; }

	public DateTime ApiStsupDateTime { get; set; }

	public int? ApiStsupCompanyId { get; set; }

	public int? ApiStsupCompanyPersonId { get; set; }

	public int? ApiStsupProjectId { get; set; }

	public bool? ApiStsupIsFixed { get; set; }

	public bool? ApiStsupIsCanceled { get; set; }

	public bool? ApiStsupIsVerified { get; set; }

	public int? ApiStsupVerifierRequestId { get; set; }

	public int? ApiStsupVerifierId { get; set; }

	public DateTime? ApiStsupVerifiedRegisterDate { get; set; }

	public int? ApiStsupVerificationWorkFlowId { get; set; }

	public int? ApiStsupPrintFormatId { get; set; }

	public string ApiStsupNote { get; set; }

	public int? ApiStsupItemCount { get; set; }

	public float? ApiStsupItemsQty { get; set; }

	public int? ApiStsupPreOrderId { get; set; }
}
