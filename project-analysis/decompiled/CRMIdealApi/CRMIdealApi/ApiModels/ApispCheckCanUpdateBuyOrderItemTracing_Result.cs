using System;

namespace CRMIdealApi.ApiModels;

public class ApispCheckCanUpdateBuyOrderItemTracing_Result
{
	public int OprItemId { get; set; }

	public int OprId { get; set; }

	public long? OprNumber { get; set; }

	public DateTime? OprDateTime { get; set; }

	public int PrdId { get; set; }

	public string PrdName { get; set; }

	public string OrpType { get; set; }
}
