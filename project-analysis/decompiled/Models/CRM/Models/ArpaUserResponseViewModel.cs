using System.Collections.Generic;

namespace CRM.Models;

public class ArpaUserResponseViewModel
{
	public List<ArpaUserInfoViewModel> data { get; set; }

	public string error { get; set; }
}
