using System.Collections.Generic;

namespace Mobile.Models;

public class LetterIndicatorResultViewModel
{
	public List<MobspLetterIndicator_Result> Letters { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
