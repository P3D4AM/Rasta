using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkOrderInfoViewModelObjects
{
	public List<LkWSOrderInfoViewModel> lst { get; set; }

	public List<LkWSOrderInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }

	public List<LkWSOrderItemsInfoViewModel> lstItems { get; set; }
}
