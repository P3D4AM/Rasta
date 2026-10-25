namespace CRM.Models;

public class CRMspSelectActiveEventPolicyTypesByPartName_Result
{
	public int EventPolicyTypeId { get; set; }

	public string PartName { get; set; }

	public string ActName { get; set; }

	public string ActTitle { get; set; }

	public string JsonSetting { get; set; }

	public int? OrderView { get; set; }

	public bool? DeActive { get; set; }
}
