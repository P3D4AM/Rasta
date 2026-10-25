using System;

namespace CRM.Models;

public class CRMspSelectUserPositionsById_Result
{
	public int PositionId { get; set; }

	public int ParentId { get; set; }

	public string PositionName { get; set; }

	public string PositionCode { get; set; }

	public string PositionNameWithCode { get; set; }

	public string PositionManager { get; set; }

	public string PositionAddress { get; set; }

	public string PositionTel { get; set; }

	public string PositionEmail { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
