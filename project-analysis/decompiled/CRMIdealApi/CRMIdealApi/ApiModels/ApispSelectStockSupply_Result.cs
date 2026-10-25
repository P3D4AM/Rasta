using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectStockSupply_Result
{
	public int ApiStockSupplyId { get; set; }

	public int ApiStockSupplyOprId { get; set; }

	public int ApiStsupReferUserId { get; set; }

	public string ApiStsupReferUser { get; set; }

	public long ApiStsupNumber { get; set; }

	public DateTime ApiStsupDateTime { get; set; }

	public int? ApiStsupCompanyId { get; set; }

	public string ApiStsupCompany { get; set; }

	public int? ApiStsupCompanyPersonId { get; set; }

	public string ApiStsupCompanyPerson { get; set; }

	public int? ApiStsupProjectId { get; set; }

	public string ApiStsupProject { get; set; }

	public bool? ApiStsupIsFixed { get; set; }

	public bool? ApiStsupIsCanceled { get; set; }

	public bool? ApiStsupIsVerified { get; set; }

	public int? ApiStsupVerifierRequestId { get; set; }

	public string ApiStsupVerifierRequest { get; set; }

	public int? ApiStsupVerifierId { get; set; }

	public string ApiStsupVerifier { get; set; }

	public DateTime? ApiStsupVerifiedRegisterDate { get; set; }

	public int? ApiStsupVerificationWorkFlowId { get; set; }

	public string ApiStsupVerificationWorkFlow { get; set; }

	public int? ApiStsupPrintFormatId { get; set; }

	public string ApiStsupPrintFormat { get; set; }

	public string ApiStsupNote { get; set; }

	public int? ApiStsupItemCount { get; set; }

	public double? ApiStsupItemsQty { get; set; }

	public int? ApiStsupPreOrderId { get; set; }

	public int ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime ApiFirstRegisterDate { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }
}
