namespace CRM.Models;

public class WSspSelectSaleCenterInMode_Result
{
	public int SaleCenterId { get; set; }

	public string SaleCenterName { get; set; }

	public int? ParentId { get; set; }

	public string ParentName { get; set; }

	public string StartTime { get; set; }

	public string EndTime { get; set; }

	public int? ReferUserId { get; set; }

	public int? ScDiffMin { get; set; }

	public string ScDiffTime { get; set; }

	public int TotalUsedMin { get; set; }

	public string TotalUsedTime { get; set; }

	public int? RemainsMin { get; set; }

	public string RemainsTime { get; set; }
}
