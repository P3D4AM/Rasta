using System.Collections.Generic;

namespace Mobile.Models;

public class IntMsgToUsersInfoViewModel
{
	public int? msgdToUserId { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }
}
