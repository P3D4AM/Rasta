using System;

namespace Mobile.Models.ViewModel.VerificationWorkFlow;

public class EditAfterFixInfoViewModel
{
	public string eafID { get; set; }

	public int eafModeId { get; set; }

	public int? eafWorkflowId { get; set; }

	public int? eafWorkflowStepId { get; set; }

	public int? eafWorkflowReqId { get; set; }

	public int eafUserId { get; set; }

	public string eafUserName { get; set; }

	public DateTime eafRequestDate { get; set; }

	public string eafRequestDatePersian { get; set; }

	public DateTime? eafEndDate { get; set; }

	public string eafEndDatePersian { get; set; }

	public bool? eafIsDone { get; set; }

	public DateTime? eafDoneDate { get; set; }

	public string eafDoneDatePersian { get; set; }
}
