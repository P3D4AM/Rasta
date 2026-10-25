namespace Mobile.Models;

public class MobspSelectOrderPaymentTypes_Result
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string ordpayTypeDescription { get; set; }

	public long? OrderView { get; set; }

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
}
