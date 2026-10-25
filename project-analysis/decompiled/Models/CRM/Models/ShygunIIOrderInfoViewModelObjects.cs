using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ShygunIIOrderInfoViewModelObjects
{
	public List<ShygunIIOrderInfoViewModel> lst { get; set; }

	public List<ShygunIIOrderInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
