using System;

namespace Mobile.Models;

public class MobspDySelectFormWorkflowStepNext_Result
{
	public int FormWorkflowStepId { get; set; }

	public int WorkflowId { get; set; }

	public string WorkflowStepTitle { get; set; }

	public int SubFormId { get; set; }

	public string ReferUserIds { get; set; }

	public int? ReferRollId { get; set; }

	public string MultiReferUserIds { get; set; }

	public string CheckerUserIds { get; set; }

	public bool? NoPrevious { get; set; }

	public bool? NoNextWithOutCheck { get; set; }

	public int? OrderView { get; set; }

	public int? ProgressPercent { get; set; }

	public bool? IsActive { get; set; }

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

	public string Workflow { get; set; }

	public string SubForm { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public string ReferUsers { get; set; }

	public string ReferRoll { get; set; }

	public string MultiReferUsers { get; set; }

	public string CheckerUsers { get; set; }
}
