using System;

namespace CRM.Models;

public class CRMspSelectAllUsersPermissionByRollId_Result
{
	public int ID { get; set; }

	public int UserId { get; set; }

	public int? RollId { get; set; }

	public int PrjId { get; set; }

	public string Description { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string AccessLevel { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string RollName { get; set; }

	public string PrjTitle { get; set; }

	public int? CId { get; set; }

	public string CenterName { get; set; }
}
