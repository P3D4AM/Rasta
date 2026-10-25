namespace CRM.Models;

public class CRMspSelectUserPositionTree_Result
{
	public int PositionId { get; set; }

	public int ParentId { get; set; }

	public string PositionName { get; set; }

	public string PositionCode { get; set; }

	public string PositionNameWithCode { get; set; }
}
