namespace CRM.Models;

public class WSspRpt_CmpOrderStockAcc_Result
{
	public long? RowNumber { get; set; }

	public int? rptUserId { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string rptUserName { get; set; }

	public int PrdId { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public string PrdFirstGroupName { get; set; }

	public string PrdFirstGroupCode { get; set; }

	public int? PrdFirstGroupOrderView { get; set; }

	public int? PrdFirstGroupId { get; set; }

	public string PrdSecondGroupName { get; set; }

	public string PrdSecondGroupCode { get; set; }

	public int? PrdSecondGroupOrderView { get; set; }

	public int? PrdSecondGroupId { get; set; }

	public string ItemQtyAndSaleJson { get; set; }

	public double? SaleOrdCountToday { get; set; }

	public string RemainCountInWarehouesesJson { get; set; }

	public int? AllPage { get; set; }

	public int? PrdOrderView { get; set; }
}
