using System;

namespace CRM.Models;

public class WSspSelectOrderPaymentTypesById_Result
{
	public int OrderPaymentTypeId { get; set; }

	public string ordpayType { get; set; }

	public string ordpayTypeDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public bool? DeActive { get; set; }

	public bool? ordpayTypeIsActivePayOnline { get; set; }

	public bool? ordpayTypeIsActiveAddFile { get; set; }

	public string ordpayTypePordFileTypeJson { get; set; }

	public string ordpayTypePordFileTypeJsonByName { get; set; }

	public string ordpayTypeOrdFileTypeJson { get; set; }

	public string ordpayTypeOrdFileTypeJsonByName { get; set; }

	public bool? ordPayTypeIsPos { get; set; }

	public string ordPayTypePosTerminal { get; set; }

	public string ordPayTypePosUserName { get; set; }

	public string ordPayTypePosPassword { get; set; }

	public string ordPayTypePosURL { get; set; }

	public bool? ordpayTypeIsChq { get; set; }

	public string TspOrdpayTypeIinn { get; set; }

	public string TspOrdpayTypeAcn { get; set; }

	public string TspOrdpayTypeTrmn { get; set; }

	public int? TspOrdpayTypePmt { get; set; }

	public int? ordpayTypeBankingBankID { get; set; }

	public string ordpayTypeBankingBank { get; set; }

	public int? ordpayTypeBankingBranchID { get; set; }

	public string ordpayTypeBankingBranch { get; set; }

	public int? ordpayTypeBankingAccountID { get; set; }

	public string ordpayTypeBankingAccount { get; set; }

	public string ordpayTypeBankingAccountNumber { get; set; }

	public int? ordpayTypeCashId { get; set; }

	public string ordpayTypeCash { get; set; }

	public int? ordpayTypeGroupIdI { get; set; }

	public string ordpayTypeGroupI { get; set; }

	public int? ordpayTypeGroupIdII { get; set; }

	public string ordpayTypeGroupII { get; set; }

	public int? ordpayTypeKind { get; set; }

	public int? ordpayTypeMode { get; set; }
}
