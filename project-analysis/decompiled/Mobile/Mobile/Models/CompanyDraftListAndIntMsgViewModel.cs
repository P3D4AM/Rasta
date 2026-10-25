using System.Collections.Generic;

namespace Mobile.Models;

public class CompanyDraftListAndIntMsgViewModel
{
	public List<MobspSelectCompanyDocs_Result> Drafts { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMessages { get; set; }
}
