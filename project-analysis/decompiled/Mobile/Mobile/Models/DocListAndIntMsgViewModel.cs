using System.Collections.Generic;

namespace Mobile.Models;

public class DocListAndIntMsgViewModel
{
	public List<MobspSelectDocs_Result> Docs { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
