using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ShygunIIPreOrderInfoViewModelObjects
{
	public List<ShygunIIPreOrderInfoViewModel> lst { get; set; }

	public List<ShygunIIPreOrderInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
