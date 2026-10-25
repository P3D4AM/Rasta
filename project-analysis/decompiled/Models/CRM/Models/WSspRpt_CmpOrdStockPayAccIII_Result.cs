namespace CRM.Models;

public class WSspRpt_CmpOrdStockPayAccIII_Result
{
	public long? RowNumber { get; set; }

	public int? rptUserId { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public string rptUserName { get; set; }

	public int PrdSecondGroupID { get; set; }

	public int FirstGroupId { get; set; }

	public string FGName { get; set; }

	public string FGCode { get; set; }

	public int? FGOrderView { get; set; }

	public string SGCode { get; set; }

	public string SGName { get; set; }

	public int? SGOrderView { get; set; }

	public string GroupName { get; set; }

	public double RemainCount { get; set; }

	public double SumSaleCount { get; set; }

	public int? AllPage { get; set; }

	public double? RemainCountInSelectedWarehoueses { get; set; }
}
