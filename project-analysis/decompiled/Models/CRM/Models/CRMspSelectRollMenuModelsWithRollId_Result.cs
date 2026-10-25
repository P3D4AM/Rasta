namespace CRM.Models;

public class CRMspSelectRollMenuModelsWithRollId_Result
{
	public int RollMenuID { get; set; }

	public int MenuModelID { get; set; }

	public string MenuModel { get; set; }

	public bool? MenuModelIsDefault { get; set; }

	public int? MenuTypeId { get; set; }

	public string MenuType { get; set; }

	public int RollId { get; set; }

	public int? OrderView { get; set; }
}
