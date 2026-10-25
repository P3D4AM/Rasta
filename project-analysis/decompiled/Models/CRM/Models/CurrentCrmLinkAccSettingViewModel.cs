using System.Collections.Generic;

namespace CRM.Models;

public class CurrentCrmLinkAccSettingViewModel
{
	public List<CRMspSelectLinkAccSetting_Result> LinkAccSettings { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }
}
