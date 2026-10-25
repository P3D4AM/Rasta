using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class KyanWareHouseInfoViewModelObjects
{
	public List<KyanWareHouseInfoViewModel> lst { get; set; }

	public List<KyanWareHouseInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
