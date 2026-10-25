using System.Collections.Generic;

namespace Mobile.Models;

public class PreOrderListAndIntMsgViewModel
{
	public List<MobspSelectPreOrdersInMode_Result> PreOrders { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
