using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectOrderPaymentTypeById_Result
{
	public int ApiOrderPaymentTypeId { get; set; }

	public string ApiOrdpayType { get; set; }

	public string ApiOrdpayTypeDescription { get; set; }

	public int ApiUserId { get; set; }

	public int ApiFPId { get; set; }

	public short ApiMonth1 { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public Guid? ApiGUId { get; set; }

	public string ApiAppType { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiLanguageID { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiLinkAccOrdPayTypeIdStr { get; set; }

	public bool? ApiDeActive { get; set; }

	public bool? ApiordpayTypeIsActivePayOnline { get; set; }

	public bool? ApiOrdpayTypeIsActiveAddFile { get; set; }

	public string ApiOrdpayTypePordFileTypeJson { get; set; }

	public string ApiOrdpayTypeOrdFileTypeJson { get; set; }

	public bool? ApiOrdpayTypeIsChq { get; set; }

	public string ApiTspOrdpayTypeIinn { get; set; }

	public string ApiTspOrdpayTypeAcn { get; set; }

	public string ApiTspOrdpayTypeTrmn { get; set; }

	public int? ApiTspOrdpayTypePmt { get; set; }

	public bool? ApiOrdPayTypeIsPos { get; set; }

	public string ApiOrdPayTypePosTerminal { get; set; }

	public string ApiOrdPayTypePosUserName { get; set; }

	public string ApiOrdPayTypePosPassword { get; set; }

	public string ApiOrdPayTypePosURL { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }

	public int? ApiOrdpayTypeBankingBankID { get; set; }

	public int? ApiordpayTypeBankingBranchID { get; set; }

	public int? ApiOrdpayTypeBankingAccountID { get; set; }

	public int? ApiOrdpayTypeCashId { get; set; }

	public int? ApiOrdpayTypeGroupIdI { get; set; }

	public int? ApiOrdpayTypeGroupIdII { get; set; }

	public int? ApiOrdpayTypeKind { get; set; }
}
