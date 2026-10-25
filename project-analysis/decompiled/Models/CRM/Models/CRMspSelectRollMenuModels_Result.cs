namespace CRM.Models;

public class CRMspSelectRollMenuModels_Result
{
	public int RollMenuID { get; set; }

	public int MenuModelId { get; set; }

	public string MenuModel { get; set; }

	public int? MenuTypeId { get; set; }

	public string MenuType { get; set; }

	public int RollId { get; set; }

	public int? OrderView { get; set; }

	public bool? RollMenuIsDefault { get; set; }

	public string RollName { get; set; }
}
