using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class KyanProductInfoViewModelObjects
{
	public List<KyanProductInfoViewModel> lst { get; set; }

	public List<KyanProductInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
