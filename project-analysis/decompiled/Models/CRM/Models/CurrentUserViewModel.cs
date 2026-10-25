namespace CRM.Models;

public class CurrentUserViewModel
{
	public CRMspSelectUsersInMode_Result CurrUser { get; set; }

	public int CurrentUserId { get; set; }

	public int NextUserId { get; set; }

	public int PreviousUserId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int FirstUserId { get; set; }

	public int LastUserId { get; set; }

	public bool? UserAccessDailyChrtAllUsers { get; set; }

	public bool? UserAccessSaleChrtAllUsers { get; set; }
}
