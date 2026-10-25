namespace Mobile.Models;

public class MobspSelectSaleCenters_Result
{
	public int SaleCenterId { get; set; }

	public string SaleCenterName { get; set; }

	public int? ParentId { get; set; }

	public int? ReferUserId { get; set; }

	public string ReferUser { get; set; }
}
