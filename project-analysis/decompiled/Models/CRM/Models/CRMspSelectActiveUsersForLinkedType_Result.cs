namespace CRM.Models;

public class CRMspSelectActiveUsersForLinkedType_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string Name { get; set; }

	public bool? IsActive { get; set; }

	public string NameWithStatus { get; set; }
}
