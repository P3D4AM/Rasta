namespace Mobile.Models;

public class UserLoginInfo
{
	public int UserId { get; set; }

	public string FullName { get; set; }

	public bool? IsActive { get; set; }

	public string RollName { get; set; }

	public string UserCIds { get; set; }

	public int? UserLastCId { get; set; }

	public int RollId { get; set; }
}
