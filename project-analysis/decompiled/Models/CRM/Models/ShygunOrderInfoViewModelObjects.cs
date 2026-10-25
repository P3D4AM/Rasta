using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ShygunOrderInfoViewModelObjects
{
	public List<ShygunOrderInfoViewModel> lst { get; set; }

	public List<ShygunOrderInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
