using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectDoc_Result
{
	public int ApiDocID { get; set; }

	public int ApiOprId { get; set; }

	public string ApiOpr { get; set; }

	public int ApiDocNumber { get; set; }

	public string ApiDocDate { get; set; }

	public int? ApiSenderId { get; set; }

	public string ApiSenderName { get; set; }

	public string ApiFactorNumber { get; set; }

	public string ApiDescription { get; set; }

	public short? ApiIsFix { get; set; }

	public int ApiWHId { get; set; }

	public string ApiWH { get; set; }

	public int ApiFPId { get; set; }

	public int? ApiOrderId { get; set; }

	public int? ApiBuyOrderId { get; set; }

	public string ApiSendAddress { get; set; }

	public string ApiDriverName { get; set; }

	public string ApiDriverTel { get; set; }

	public string ApiFreightName { get; set; }

	public string ApiBijakNumber { get; set; }

	public string ApiCarNumber { get; set; }

	public DateTime? ApiDocDateTime { get; set; }

	public int? ApiWHIdI { get; set; }

	public string ApiWHI { get; set; }

	public int? ApiCompanyId { get; set; }

	public string ApiCompany { get; set; }

	public int? ApiCompanyPersonId { get; set; }

	public string ApiCompanyPerson { get; set; }

	public int? ApiProjectId { get; set; }

	public string ApiProject { get; set; }

	public string ApicmpTitle { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiDocLinkAccCodeId { get; set; }

	public string ApiDocLinkAccCode { get; set; }

	public int? ApiDocLinkAccDocId { get; set; }

	public string ApiDocLinkAccDocNumber { get; set; }

	public int? ApiDocLinkAccVoucherId { get; set; }

	public string ApiDocLinkAccVoucherNumber { get; set; }

	public string ApiDocLinkAccDocIdStr { get; set; }

	public string ApiDocLinkAccDocType { get; set; }

	public DateTime? ApiDocLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiDocLinkAccLastTransferDate { get; set; }

	public string ApiDocLinkAccData { get; set; }

	public int? ApiDocCId { get; set; }

	public long? ApiRowNumber { get; set; }

	public int? ApiTotalCount { get; set; }
}
