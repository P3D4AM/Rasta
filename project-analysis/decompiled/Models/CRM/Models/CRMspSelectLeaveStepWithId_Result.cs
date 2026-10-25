using System;

namespace CRM.Models;

public class CRMspSelectLeaveStepWithId_Result
{
	public int LeaveStepID { get; set; }

	public int LeaveStepGroupId { get; set; }

	public string LeaveStepGroup { get; set; }

	public string lsTitle { get; set; }

	public bool? lsInActive { get; set; }

	public bool? lsIsRequired { get; set; }

	public int? OrderView { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public string EditUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string LeaveStepLangJson { get; set; }
}
