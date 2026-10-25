using System.Collections.Generic;

namespace Mobile.Models;

public class CompanyDocListAndIntMsgViewModel
{
	public List<MobspSelectCompanyDocs_Result> Docs { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
