namespace CRM.Models;

public class CRMspLkWSSelectProduct_Result
{
	public int ProductID { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdSGroupName { get; set; }

	public int? PrdFGroupId { get; set; }

	public string PrdFGroupName { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public int? PrdLinkAccPrdId { get; set; }

	public string PrdLinkAccPrdIdStr { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public int? PrdUnitId { get; set; }

	public string PrdUnit { get; set; }

	public string PrdBarCode { get; set; }

	public long? RowNumber { get; set; }

	public string ListItemRecords { get; set; }
}
