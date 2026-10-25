using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ShygunDocInfoViewModelObjects
{
	public List<ShygunDocInfoViewModel> lst { get; set; }

	public List<ShygunDocInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
