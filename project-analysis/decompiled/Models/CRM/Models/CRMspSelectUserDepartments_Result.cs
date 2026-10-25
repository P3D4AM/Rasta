using System;

namespace CRM.Models;

public class CRMspSelectUserDepartments_Result
{
	public int DepartmentID { get; set; }

	public string Department { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? DefaultTicketUserId { get; set; }

	public string DefaultTicketUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int? LeaveVerificationWorkFlowId { get; set; }

	public int? MissionVerificationWorkFlowId { get; set; }

	public string LeaveVerificationWorkFlow { get; set; }

	public string MissionVerificationWorkFlow { get; set; }

	public int? CId { get; set; }

	public string CenterName { get; set; }

	public string CenterCode { get; set; }
}
