namespace CRMIdealApi.ApiModels;

public class ApifnCheckDuplicateBuyOrderPrdSerial_Result
{
	public int BuyOrderItemSerialID { get; set; }

	public int BuyOrderItemId { get; set; }

	public string Serial { get; set; }

	public int? SerialId { get; set; }

	public int? StatusId { get; set; }

	public int bordIPrdId { get; set; }

	public string PrdName { get; set; }

	public long bordNumber { get; set; }
}
