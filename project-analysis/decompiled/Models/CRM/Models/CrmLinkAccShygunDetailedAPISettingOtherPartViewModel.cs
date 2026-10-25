using System.Collections.Generic;

namespace CRM.Models;

public class CrmLinkAccShygunDetailedAPISettingOtherPartViewModel
{
	public List<CRMspSelectLinkAccSettingDetails_Result> CmpMoeinAccCodeSettingDetails { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> PrdCodeSettingPart { get; set; }

	public bool? CmpAccFromLink { get; set; }
}
