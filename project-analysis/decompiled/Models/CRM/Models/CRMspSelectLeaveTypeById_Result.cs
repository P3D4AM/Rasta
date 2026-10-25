using System;

namespace CRM.Models;

public class CRMspSelectLeaveTypeById_Result
{
	public int LeaveTypeID { get; set; }

	public string LeaveType { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? LeaveOpr { get; set; }

	public string TermText { get; set; }

	public string LeaveTypeLang { get; set; }

	public string FirstRegisterUser { get; set; }
}
