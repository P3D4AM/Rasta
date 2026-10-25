namespace Mobile.Models;

public class DocItemImportExcelViewModel
{
	public int RowNumber { get; set; }

	public int ProductId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public double Quantity { get; set; }

	public string Description { get; set; }

	public double? FCR { get; set; }

	public double? FCRI { get; set; }

	public string Tracing { get; set; }

	public int? PrdUnitId { get; set; }

	public string PrdUnit { get; set; }

	public double? QuantityTotal { get; set; }

	public int? PrdUnitIdI { get; set; }

	public string PrdUnitI { get; set; }

	public double? PrdUnitIRateResult { get; set; }

	public bool Selected { get; set; }

	public bool HasConflict { get; set; }

	public string ConflictDesc { get; set; }

	public string ConflictErrorDb { get; set; }

	public int? PrdUnitIdII { get; set; }

	public string PrdUnitII { get; set; }

	public double? PrdUnitIIRateResult { get; set; }
}
