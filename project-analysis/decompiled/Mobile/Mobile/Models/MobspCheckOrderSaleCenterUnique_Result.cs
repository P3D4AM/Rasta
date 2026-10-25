namespace Mobile.Models;

public class MobspCheckOrderSaleCenterUnique_Result
{
	public int OrderItemID { get; set; }

	public int ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public int? ordISaleCenterId { get; set; }

	public int? SaleCenterParentId { get; set; }
}
