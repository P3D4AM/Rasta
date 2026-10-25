namespace CRM.Models;

public class CRMspReturnRollDiscountLimitation_Result
{
	public int Id { get; set; }

	public string RollName { get; set; }

	public bool? LimitPreOrderDiscountActive { get; set; }

	public decimal? LimitPreOrderDiscountPercent { get; set; }

	public bool? LimitOrderDiscountActive { get; set; }

	public decimal? LimitOrderDiscountPercent { get; set; }
}
