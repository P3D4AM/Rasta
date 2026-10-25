using System.Collections.Generic;

namespace CRM.Models;

public class PayRollUserCycleItemValuesViewModel
{
	public int CycleId { get; set; }

	public int ItemKind { get; set; }

	public string ValueDetails { get; set; }

	public List<UserCycleItemValuesViewModel> ItemValues { get; set; }
}
