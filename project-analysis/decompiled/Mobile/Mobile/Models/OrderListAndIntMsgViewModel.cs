using System.Collections.Generic;

namespace Mobile.Models;

public class OrderListAndIntMsgViewModel
{
	public List<MobspSelectOrdersInMode_Result> Orders { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
