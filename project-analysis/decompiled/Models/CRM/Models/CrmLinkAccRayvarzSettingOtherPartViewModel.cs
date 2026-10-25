using System.Collections.Generic;

namespace CRM.Models;

public class CrmLinkAccRayvarzSettingOtherPartViewModel
{
	public List<CRMspSelectLinkAccSetting_Result> CmpAccountRemainPart { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> PreOrderPart { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> PrdCodeSettingPart { get; set; }

	public bool? CmpAccFromLink { get; set; }

	public List<CRMspSelectLinkAccSetting_Result> OrderPart { get; set; }

	public List<CRMspSelectLinkAccSettingDetails_Result> SaleCenterPart { get; set; }
}
