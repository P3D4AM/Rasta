namespace CRM.Models;

public class WSspCheckDuplicateBuyOrderItemTracing_Result
{
	public int BuyOrderItemId { get; set; }

	public int BuyOrderId { get; set; }

	public long? bordNumber { get; set; }

	public int bordIPrdId { get; set; }

	public string PrdName { get; set; }
}
