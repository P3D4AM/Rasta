using System.Collections.Generic;

namespace Mobile.Models;

public class CompanySendLetterListAndIntMsgViewModel
{
	public List<MobspSelectCompanyLetters_Result> Letters { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
