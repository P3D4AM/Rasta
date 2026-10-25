using System.Collections.Generic;

namespace Mobile.Hubs;

public class UserCompanySignalR
{
	public string UserId { get; set; }

	public string CompanyId { get; set; }

	public HashSet<string> ConnectionIds { get; set; }
}
