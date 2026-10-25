using System;

namespace CRM.Models;

public class WSspSelectPreOrderPrdGroupMustExistReasons_Result
{
	public string ReasonGroupTitle { get; set; }

	public int PrdGroupMustExistReasonId { get; set; }

	public int PrdGroupMustExistReasonGroupId { get; set; }

	public int? CompanyId { get; set; }

	public int cmpProjectId { get; set; }

	public int? PreOrderId { get; set; }

	public int PrdFirstGroupID { get; set; }

	public string Reason { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
