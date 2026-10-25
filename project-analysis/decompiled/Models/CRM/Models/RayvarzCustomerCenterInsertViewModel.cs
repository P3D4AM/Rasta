namespace CRM.Models;

public class RayvarzCustomerCenterInsertViewModel
{
	public string name { get; set; }

	public string nameEn { get; set; }

	public long? centerGroupId { get; set; }

	public long? centerEqualCodeId { get; set; }

	public int isActive { get; set; }

	public int hasDetails { get; set; }

	public long? parentCenterId { get; set; }

	public long? personId { get; set; }

	public string person { get; set; }

	public long[] centerGroupIdsCollection { get; set; }

	public string rowVersion { get; set; }
}
