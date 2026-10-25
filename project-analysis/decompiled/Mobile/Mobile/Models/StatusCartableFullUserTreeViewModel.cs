using System.Collections.Generic;

namespace Mobile.Models;

public class StatusCartableFullUserTreeViewModel
{
	public MobspUserTreeStatusCartable_Result User { get; set; }

	public List<MobspUserTreeStatusCartableByStatus_Result> UserStatus { get; set; }
}
