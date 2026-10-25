namespace CRMIdealApi.ApiModels;

public class LkWSOrderViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserId { get; set; }

	public int? LanguageId { get; set; }

	public int? ApiOrderId { get; set; }

	public long? ApiOrdNumber { get; set; }

	public int? ApiOrderOprId { get; set; }

	public int? ApiLinkAccOrdType { get; set; }

	public int? ApiLinkAccSettingDBId { get; set; }

	public int? ApiLinkAccFiscalYearId { get; set; }

	public int? ApiLinkAccUserId { get; set; }

	public bool? ApiSendOrdPayToAcc { get; set; }

	public bool? ApiSendPreOrderToAcc { get; set; }

	public bool? ApiSendPordPayToAcc { get; set; }

	public bool? ApiSendDocToAcc { get; set; }

	public int? ApiLinkAccInventoryType { get; set; }

	public int? ApiLinkAccDocType { get; set; }

	public bool? ApiLinkAccInvIsReturn { get; set; }

	public bool? ApiSendOrdCommToAcc { get; set; }
}
