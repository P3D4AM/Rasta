namespace Mobile.Models;

public class ReminderViewModel
{
	public string Date { get; set; }

	public int UserId { get; set; }

	public int GroupId { get; set; }

	public int PriorityId { get; set; }

	public bool SelectWithCnvs { get; set; }

	public int DidItStatus { get; set; }

	public string FileName { get; set; }

	public int PrintFormatId { get; set; }

	public int? Ln { get; set; }

	public int? PfCId { get; set; }
}
