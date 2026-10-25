using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkPreOrderInfoViewModelObjects
{
	public List<LkWSPreOrderInfoViewModel> lst { get; set; }

	public List<LkWSPreOrderInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }

	public List<LkWSPreOrderItemsInfoViewModel> lstItems { get; set; }
}
