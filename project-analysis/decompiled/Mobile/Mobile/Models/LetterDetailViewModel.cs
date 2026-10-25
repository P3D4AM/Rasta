using System.Collections.Generic;

namespace Mobile.Models;

public class LetterDetailViewModel
{
	public MobspSelectLetterWithID_Result Letter { get; set; }

	public List<MobspSelectFilesDirectory_Result> LetterFiles { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMsg { get; set; }
}
