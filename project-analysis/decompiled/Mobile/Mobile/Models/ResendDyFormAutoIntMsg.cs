namespace Mobile.Models;

public class ResendDyFormAutoIntMsg
{
	public int formId { get; set; }

	public int mValId { get; set; }

	public int workflowId { get; set; }

	public int workflowStepId { get; set; }

	public string referUserIds { get; set; }

	public string multiReferUserIds { get; set; }

	public string checkerUserIds { get; set; }

	public bool sendAutoMsgToMultiReferUsers { get; set; }

	public bool sendAutoMsgToCheckerUsers { get; set; }

	public int? masterValueDetailId { get; set; }

	public int? firstWorkflowStepId { get; set; }

	public string mainFormReferUserIs { get; set; }

	public int? cId { get; set; }
}
