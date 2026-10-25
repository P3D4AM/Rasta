using System;

namespace CRMIdealApi.ApiModels;

public class SelectUsersViewModel
{
	public int ApiUserId { get; set; }

	public string ApiFName { get; set; }

	public string ApiLName { get; set; }

	public string ApiFullName { get; set; }

	public bool? ApiIsActive { get; set; }

	public string ApiUserName { get; set; }

	public DateTime? ApiStartDate { get; set; }

	public DateTime? ApiExpireDate { get; set; }

	public string ApiDescription { get; set; }
}
