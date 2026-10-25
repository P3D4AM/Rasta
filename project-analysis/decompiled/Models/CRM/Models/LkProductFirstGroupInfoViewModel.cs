using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class LkProductFirstGroupInfoViewModel
{
	[Key]
	public int PrdFirstGroupID { get; set; }

	public string FGCode { get; set; }

	public string FGName { get; set; }

	public string FGDescription { get; set; }

	public int? FGLinkAccGroupId { get; set; }

	public string FGLinkAccGroupCode { get; set; }

	public string FGLinkAccGroupIdStr { get; set; }

	public int RowNumber { get; set; }

	public bool Selected { get; set; }
}
