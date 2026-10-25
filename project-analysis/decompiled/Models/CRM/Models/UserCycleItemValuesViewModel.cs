namespace CRM.Models;

public class UserCycleItemValuesViewModel
{
	public int PayRollUserCycleItemValueId { get; set; }

	public int ItemId { get; set; }

	public decimal? Value { get; set; }

	public string UsefulIds { get; set; }

	public string ItemName { get; set; }

	public int ItemTypeId { get; set; }

	public string ItemType { get; set; }

	public string ItemFormula { get; set; }

	public bool? ItemJustForShow { get; set; }

	public bool? ValueNotValid { get; set; }

	public string ItemValueDesc { get; set; }

	public string ItemValueDesc_Lang { get; set; }

	public string ValueStr { get; set; }
}
