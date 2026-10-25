namespace Mobile.Models;

public class SHPMobspSelectProductWithPriceByPrdId_Result
{
	public int PrdId { get; set; }

	public int PrdGroupId { get; set; }

	public string PName { get; set; }

	public string PrdGroup { get; set; }

	public string PrdCode { get; set; }

	public string PrdModel { get; set; }

	public string PrdLatinName { get; set; }

	public string PrdBarcode { get; set; }

	public string PrdColor { get; set; }

	public int? PrdUnitId { get; set; }

	public string PrdUnit { get; set; }

	public int? PrdQuantityInUnit { get; set; }

	public double? FCR { get; set; }

	public double? FCRI { get; set; }

	public string PrdType { get; set; }

	public string PrdDesign { get; set; }

	public string PrdSize { get; set; }

	public string PrdFirstBarcode { get; set; }

	public string PrdDescription { get; set; }

	public bool? PrdIsDefault { get; set; }

	public bool? PrdInActive { get; set; }

	public int? PrdKind { get; set; }

	public string PrdDefQuantity { get; set; }

	public bool? PrdJustDefQuantity { get; set; }

	public double? PrdMinQuantity { get; set; }

	public double? PrdMaxQuantity { get; set; }

	public decimal? PrdPrice { get; set; }

	public int? OrderView { get; set; }
}
