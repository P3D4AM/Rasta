namespace CRM.Models;

public class DyFormReportsViewModel
{
	public string ValueDetails { get; set; }

	public int FormId { get; set; }

	public string FromFirstRegisterDate { get; set; }

	public string ToFirstRegisterDate { get; set; }

	public string FromRegisterDate { get; set; }

	public string ToRegisterDate { get; set; }

	public string CompanyId { get; set; }

	public string CompanyName { get; set; }

	public string CheckedStatusId { get; set; }

	public string FirstRegisterUserId { get; set; }

	public string RegisterUserId { get; set; }

	public int? MasterValueId { get; set; }

	public string FromCheckedDate { get; set; }

	public string ToCheckedDate { get; set; }

	public string CheckerUserId { get; set; }

	public string DyFormNumber { get; set; }

	public string VerificationWorkFlowId { get; set; }

	public string VerificationWorkFlowSetpId { get; set; }
}
