using System.Collections.Generic;

namespace Mobile.Models;

public class DraftListAndIntMsgViewModel
{
	public List<MobspSelectDocs_Result> Drafts { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
