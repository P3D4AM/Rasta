using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class UsersListViewModel
{
	[Key]
	public int UserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserFName")]
	public string FName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserLName")]
	public string LName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserPersCode")]
	public string PersCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserName")]
	public string UserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "UserRollId")]
	public string RollIdTitle { get; set; }

	public bool UserIsActiveInWebApp { get; set; }

	public bool UserIsActiveInMobApp { get; set; }
}
