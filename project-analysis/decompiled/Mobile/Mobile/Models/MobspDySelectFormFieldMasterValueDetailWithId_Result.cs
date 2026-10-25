using System;

namespace Mobile.Models;

public class MobspDySelectFormFieldMasterValueDetailWithId_Result
{
	public int FormFieldMasterValueDetailId { get; set; }

	public int MasterValueId { get; set; }

	public int FormId { get; set; }

	public string FormName { get; set; }

	public string FormTitle { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsChecked { get; set; }

	public int? CheckerUserId { get; set; }

	public string CheckerUser { get; set; }

	public DateTime? CheckedDate { get; set; }

	public string CheckedDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public string RegisterUser { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? WorkflowId { get; set; }

	public string Workflow { get; set; }

	public int? WorkflowStepId { get; set; }

	public string WorkflowStep { get; set; }

	public int? ProgressPercent { get; set; }
}
