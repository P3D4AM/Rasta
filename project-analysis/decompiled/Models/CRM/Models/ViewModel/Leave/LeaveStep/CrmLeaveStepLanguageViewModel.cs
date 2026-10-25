namespace CRM.Models.ViewModel.Leave.LeaveStep;

public class CrmLeaveStepLanguageViewModel
{
	public int LeaveStepID { get; set; }

	public int LeaveStepGroupId { get; set; }

	public string lsTitle { get; set; }

	public bool? lsInActive { get; set; }

	public bool? lsIsRequired { get; set; }

	public int? OrderView { get; set; }

	public string lsTitle_Lang { get; set; }
}
