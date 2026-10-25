namespace CRM.Models;

public class WSspRpt_ParadoxOrderItemWithDraftItem_Result
{
	public int? Ocnt { get; set; }

	public int? Dcnt { get; set; }

	public string ordDate { get; set; }

	public long ordNumber { get; set; }

	public int? OrderOprID { get; set; }

	public string Opr { get; set; }

	public string Company { get; set; }

	public int OrderId { get; set; }

	public int ordCompanyId { get; set; }

	public double? SumOrdItemQuantity { get; set; }

	public double? SumDocItemQuantity { get; set; }
}
