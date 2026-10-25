namespace CRM.Models;

public class WSProductUnitsListViewModel
{
	public int ProductUnitID { get; set; }

	public string Unit { get; set; }

	public int? QuantityInUnit { get; set; }

	public string UnitEn { get; set; }

	public double? FCR { get; set; }

	public double? FCRI { get; set; }
}
