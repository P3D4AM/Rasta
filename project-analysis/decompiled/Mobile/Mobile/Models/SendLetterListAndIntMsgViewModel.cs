using System.Collections.Generic;

namespace Mobile.Models;

public class SendLetterListAndIntMsgViewModel
{
	public List<MobspLetterIndicator_Result> Letters { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
