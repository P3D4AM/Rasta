using System.Collections.Generic;

namespace Mobile.Models;

public class WarehouseMovementListAndIntMsgViewModel
{
	public List<MobspSelectDocs_Result> Movements { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
