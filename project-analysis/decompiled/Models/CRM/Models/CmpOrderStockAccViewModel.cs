namespace CRM.Models;

public class CmpOrderStockAccViewModel
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

	public int? PrdOrderView { get; set; }

	public int? WHId { get; set; }

	public string WrhsName { get; set; }

	public int? OrderView { get; set; }

	public double? PrdUnitIRate { get; set; }

	public double? FCR { get; set; }

	public string Tracing { get; set; }

	public double? RemainCount { get; set; }

	public double? SaleOrdCountMonth1 { get; set; }

	public double? SaleOrdCountMonth2 { get; set; }

	public double? SaleOrdCountMonth3 { get; set; }

	public double? SaleOrdCountMonth4 { get; set; }

	public double? SaleOrdCountMonth5 { get; set; }

	public double? SaleOrdCountMonth6 { get; set; }

	public double? SaleOrdCountMonth7 { get; set; }

	public double? SaleOrdCountMonth8 { get; set; }

	public double? SaleOrdCountMonth9 { get; set; }

	public double? SaleOrdCountMonth10 { get; set; }

	public double? SaleOrdCountMonth11 { get; set; }

	public double? SaleOrdCountMonth12 { get; set; }

	public double? RemainCountNoTracing { get; set; }

	public double? SaleOrdCountToday { get; set; }

	public double? SelectedWrhsTotalStock { get; set; }

	public int? AllPage { get; set; }
}
