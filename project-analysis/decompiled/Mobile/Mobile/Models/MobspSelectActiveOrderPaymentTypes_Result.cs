namespace Mobile.Models;

public class MobspSelectActiveOrderPaymentTypes_Result
{
	public int OrderPaymentTypeId { get; set; }

	public string ordpayType { get; set; }

	public string ordpayTypeDescription { get; set; }

	public bool? ordpayTypeIsActivePayOnline { get; set; }

	public bool? ordpayTypeIsActiveAddFile { get; set; }

	public string ordpayTypePordFileTypeJson { get; set; }

	public string ordpayTypePordFileTypeJsonByName { get; set; }

	public string ordpayTypeOrdFileTypeJson { get; set; }

	public string ordpayTypeOrdFileTypeJsonByName { get; set; }

	public bool? ordpayTypeIsChq { get; set; }

	public int? ordpayTypeBankingBankID { get; set; }

	public string BankingBankName { get; set; }

	public int? ordpayTypeBankingBranchID { get; set; }

	public string BankingBranchName { get; set; }

	public int? ordpayTypeBankingAccountID { get; set; }

	public string BankingAccountTitle { get; set; }

	public int? ordpayTypeCashId { get; set; }

	public string CashTitle { get; set; }

	public int? ordpayTypeGroupIdI { get; set; }

	public string ordpayGroupIName { get; set; }

	public int? ordpayTypeGroupIdII { get; set; }

	public string ordpayGroupIIName { get; set; }

	public int? ordpayTypeKind { get; set; }

	public string ordpayTypeKindTitle { get; set; }

	public string TspOrdPayTypeAcn { get; set; }

	public string TspOrdpayTypeIinn { get; set; }

	public int? TspOrdpayTypePmt { get; set; }

	public string TspOrdpayTypeTrmn { get; set; }

	public int? ordpayTypeMode { get; set; }
}
