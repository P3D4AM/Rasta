namespace CRMIdealApi.ApiModels;

public class IssueDocItemsViewModel
{
	public int? ItemId { get; set; }

	public int? PrdId { get; set; }

	public string PrdCode { get; set; }

	public double? Quantity { get; set; }

	public decimal? Cost { get; set; }

	public string Description { get; set; }

	public bool? IsFix { get; set; }

	public int? WHId { get; set; }

	public bool? NotVisible { get; set; }

	public double? FCR { get; set; }

	public double? FCRI { get; set; }

	public string Tracing { get; set; }

	public int? PrdUnitId { get; set; }

	public string PrdUnit { get; set; }
}
