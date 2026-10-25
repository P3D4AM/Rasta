using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ShygunPreOrderInfoViewModelObjects
{
	public List<ShygunPreOrderInfoViewModel> lst { get; set; }

	public List<ShygunPreOrderInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
