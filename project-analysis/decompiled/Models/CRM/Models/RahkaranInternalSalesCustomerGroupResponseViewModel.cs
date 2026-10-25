namespace CRM.Models;

public class RahkaranInternalSalesCustomerGroupResponseViewModel
{
	public string Name { get; set; }

	public string EntityName { get; set; }

	public string SubtypeTitle_Display { get; set; }

	public bool IsNonDisjoint { get; set; }

	public string IsNonDisjoint_Display { get; set; }

	public bool IntermediateGroupMembershipAllowed { get; set; }

	public string IntermediateGroupMembershipAllowed_Display { get; set; }

	public long? ID { get; set; }
}
