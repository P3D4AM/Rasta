namespace CRMIdealApi.ApiModels;

public class ApispSelectUsersById_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string FullName { get; set; }

	public bool? IsActive { get; set; }

	public bool? UserIsActiveInWebApp { get; set; }
}
