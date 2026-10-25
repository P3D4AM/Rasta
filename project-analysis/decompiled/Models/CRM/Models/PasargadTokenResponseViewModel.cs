using System.Collections.Generic;

namespace CRM.Models;

public class PasargadTokenResponseViewModel
{
	public string resultMsg { get; set; }

	public int? resultCode { get; set; }

	public string token { get; set; }

	public string username { get; set; }

	public string firstName { get; set; }

	public string lastName { get; set; }

	public string userId { get; set; }

	public List<PasargadRoleTokenResponseViewModel> roles { get; set; }
}
