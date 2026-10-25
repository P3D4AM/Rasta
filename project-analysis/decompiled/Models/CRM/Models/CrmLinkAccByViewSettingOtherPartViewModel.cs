using System.Collections.Generic;

namespace CRM.Models;

public class CrmLinkAccByViewSettingOtherPartViewModel
{
	public List<CRMspSelectLinkAccByViewSetting_Result> SettingPart { get; set; }

	public bool? CmpAccFromLink { get; set; }
}
