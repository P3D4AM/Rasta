using System.Collections.Generic;

namespace CRMIdeal.Hubs;

public class UsersSignalR
{
	public string Id { get; set; }

	public HashSet<string> ConnectionIds { get; set; }
}
