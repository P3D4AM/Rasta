using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ShygunIIDocInfoViewModelObjects
{
	public List<ShygunIIDocInfoViewModel> lst { get; set; }

	public List<ShygunIIDocInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
