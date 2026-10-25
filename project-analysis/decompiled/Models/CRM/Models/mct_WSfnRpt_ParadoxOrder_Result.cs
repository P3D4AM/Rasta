namespace CRM.Models;

public class mct_WSfnRpt_ParadoxOrder_Result
{
	public string ordDate { get; set; }

	public long ordNumber { get; set; }

	public int OrderOprID { get; set; }

	public string Opr { get; set; }

	public string Company { get; set; }

	public int OrderId { get; set; }

	public int ordCompanyId { get; set; }

	public int? Dcnt { get; set; }

	public int? Ocnt { get; set; }
}
