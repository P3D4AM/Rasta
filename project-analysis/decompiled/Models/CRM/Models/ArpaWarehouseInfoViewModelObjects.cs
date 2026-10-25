using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ArpaWarehouseInfoViewModelObjects
{
	public List<LkWareHouseInfoViewModel> lst { get; set; }

	public List<LkWareHouseInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
