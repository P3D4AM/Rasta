namespace CRM.Models;

public class WSspSelectProductOrdIssueByPordId_Result
{
	public int ProductID { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public string PrdSGroupName { get; set; }

	public string PrdSGroupCode { get; set; }

	public int? PrdFGroupId { get; set; }

	public string PrdFGroupName { get; set; }

	public string PrdFGroupCode { get; set; }

	public bool? PrdOrdIssueSetSetting { get; set; }

	public int? PrdOrdIssuePrjTitleGroupId { get; set; }

	public string PrdOrdIssuePrjTitleGroup { get; set; }

	public int? PrdOrdIssuePrjTitleId { get; set; }

	public string PrdOrdIssuePrjTitle { get; set; }

	public string PrdOrdIssuePrjPostFix { get; set; }

	public int? PrdOrdIssuePrjCnvsStatusGroupId { get; set; }

	public string PrdOrdIssuePrjCnvsStatusGroup { get; set; }

	public int? PrdOrdIssuePrjRemindDay { get; set; }

	public bool? PrdOrdIssuePrjFOCmpCanSee { get; set; }

	public bool? PrdOrdIssuePrjIsTicket { get; set; }

	public int? PrdOrdIssuePrjUsedType { get; set; }
}
