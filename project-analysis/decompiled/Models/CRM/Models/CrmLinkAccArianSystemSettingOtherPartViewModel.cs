using System.Collections.Generic;

namespace CRM.Models;

public class CrmLinkAccArianSystemSettingOtherPartViewModel
{
	public List<CRMspSelectLinkAccSettingDetails_Result> CmpPersonTypeAccSettingDetails { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> PrdCodeSettingPart { get; set; }

	public bool? CmpAccFromLink { get; set; }
}
