namespace CRM.Models;

public class LkCenterInfoViewModel
{
	public int? ParentId { get; set; }

	public string ParentCode { get; set; }

	public int? CenterID { get; set; }

	public string CenterCode { get; set; }

	public string CenterName { get; set; }

	public string CenterDesc { get; set; }

	public bool? CenterInActive { get; set; }

	public int? OrderView { get; set; }

	public string LinkAccCenterIdStr { get; set; }

	public string LinkAccCenterCode { get; set; }

	public string LinkAccData { get; set; }
}
