namespace CRM.Models;

public class WSspSelectActiveUsersForWrhsPermission_Result
{
	public int UserId { get; set; }

	public string FullName { get; set; }

	public int UserHasPermission { get; set; }
}
