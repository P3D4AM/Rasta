namespace CRM.Models;

public class CRMspLkSepWSLinkedWareHouse_Result
{
	public int? WareHouseID { get; set; }

	public string WrhsName { get; set; }

	public string WrhsCode { get; set; }

	public int? WrhsLinkAccWhId { get; set; }

	public string WrhsLinkAccWhCode { get; set; }

	public int? ErrorType { get; set; }

	public int? Type { get; set; }
}
