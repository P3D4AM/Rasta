namespace CRM.Models;

public class ReturnPrdQuantityViewModel
{
	public WSspReturnPrdQuantity_Result PrdQuantity { get; set; }

	public double ValidpordQuantity { get; set; }

	public double QtyRemain { get; set; }

	public string ValidpordQuantityTotal { get; set; }

	public double SoldOrdPrdQuantity { get; set; }

	public string SoldOrdPrdQuantityTotal { get; set; }

	public double RemainSoldOrdPrdQuantity { get; set; }
}
