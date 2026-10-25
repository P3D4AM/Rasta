using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class LkProductGroupInfoViewModel
{
	[Key]
	public int PrdGroupID { get; set; }

	public int ParentGroupId { get; set; }

	public string GroupCode { get; set; }

	public string GroupName { get; set; }

	public string GroupDescription { get; set; }

	public string LinkAccGroupCode { get; set; }

	public string LinkAccGroupIdStr { get; set; }

	public string LinkAccGroupName { get; set; }

	public string ParentGroupCode { get; set; }

	public string ParentGroupName { get; set; }

	public string ParentLinkAccGroupCode { get; set; }

	public string ParentLinkAccGroupIdStr { get; set; }

	public string ParentLinkAccGroupName { get; set; }

	public int RowNumber { get; set; }

	public bool Selected { get; set; }
}
