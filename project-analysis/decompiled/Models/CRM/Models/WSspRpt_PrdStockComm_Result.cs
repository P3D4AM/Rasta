namespace CRM.Models;

public class WSspRpt_PrdStockComm_Result
{
	public string rptUserName { get; set; }

	public string rptDate { get; set; }

	public string rptDay { get; set; }

	public int ProductID { get; set; }

	public string PrdName { get; set; }

	public string PrdCode { get; set; }

	public int SGId { get; set; }

	public string SGName { get; set; }

	public string SGCode { get; set; }

	public int? FGId { get; set; }

	public string FGName { get; set; }

	public string FGCode { get; set; }

	public int? OrderView { get; set; }

	public double? QuantityIn { get; set; }

	public double? QuantityOut { get; set; }

	public double PordRemainQuantity { get; set; }

	public double BordRemainQuantity { get; set; }

	public double RemainQuantity { get; set; }

	public double SalableQuantity { get; set; }

	public double TotalRemainQuantity { get; set; }
}
