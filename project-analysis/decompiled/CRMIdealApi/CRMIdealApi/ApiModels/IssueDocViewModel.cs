using System;

namespace CRMIdealApi.ApiModels;

public class IssueDocViewModel : PublicParameters
{
	public int? ApiDocOprId { get; set; }

	public int? ApiDocNumber { get; set; }

	public DateTime? ApiDocDateTime { get; set; }

	public int? ApiDocSenderId { get; set; }

	public string ApiDocSenderName { get; set; }

	public string ApiDocFactorNumber { get; set; }

	public string ApiDocDescription { get; set; }

	public short? ApiDocIsFix { get; set; }

	public int? ApiDocWHId { get; set; }

	public int? ApiDocOrderId { get; set; }

	public int? ApiDocBuyOrderId { get; set; }

	public string ApiDocSendAddress { get; set; }

	public string ApiDocDriverName { get; set; }

	public string ApiDocDriverTel { get; set; }

	public string ApiDocFreightName { get; set; }

	public string ApiDocBijakNumber { get; set; }

	public string ApiDocCarNumber { get; set; }

	public int? ApiDocWHIdI { get; set; }

	public string ApiDocCmpTitle { get; set; }

	public int? ApiDocDocLinkAccCodeId { get; set; }

	public string ApiDocDocLinkAccCode { get; set; }

	public int? ApiDocDocLinkAccDocId { get; set; }

	public string ApiDocDocLinkAccDocNumber { get; set; }

	public int? ApiDocDocLinkAccVoucherId { get; set; }

	public string ApiDocDocLinkAccVoucherNumber { get; set; }

	public int? ApiCompanyId { get; set; }

	public int? ApiCompanyNumber { get; set; }

	public string ApiCompanyCode { get; set; }

	public int? ApiCompanyPersonId { get; set; }

	public int? ApiProjectId { get; set; }

	public string ApiProjectTitle { get; set; }

	public string ApiDocItemsInJsonFormat { get; set; }

	public string ApiDocItemSerialsInJsonFormat { get; set; }

	public string ApiDocLinkAccDocIdStr { get; set; }

	public string ApiDocLinkAccDocType { get; set; }

	public DateTime? ApiDocLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiDocLinkAccLastTransferDate { get; set; }

	public string ApiDocLinkAccData { get; set; }
}
