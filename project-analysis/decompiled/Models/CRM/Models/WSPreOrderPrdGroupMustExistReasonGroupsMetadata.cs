using System;

namespace CRM.Models;

public class WSPreOrderPrdGroupMustExistReasonGroupsMetadata
{
	public int PrdGroupMustExistReasonGroupId { get; set; }

	public string PrdGroupMustExistReasonGroupTitle { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }
}
