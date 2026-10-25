namespace CRM.Models;

public class EmailSendFoLoginInfoViewModel
{
	public string EmailAddress { get; set; }

	public int? EmailCmpId { get; set; }

	public int? EmailCmpPrsId { get; set; }

	public int? EmailCmpPrjId { get; set; }

	public string EmailCmpPrsName { get; set; }

	public string EmailCmpName { get; set; }

	public string EmailPrsJob { get; set; }

	public int StatusId { get; set; }

	public int PriorityId { get; set; }

	public string CmpPassword { get; set; }
}
